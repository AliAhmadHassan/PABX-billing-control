using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.ImportaBilhetagem
{
    class Program
    {


        static void Main(string[] args)
        {
            if (args.Contains("\\g")
                || args.Contains("\\t1")
                || args.Contains("\\t2")
                || args.Contains("\\t3"))
                while (true)
                {
                    if (args.Contains("\\g"))
                        ProcessaGennex();
                    if (args.Contains("\\t1"))
                        ProcessaTotalIP("192.168.0.39", 1);
                    if (args.Contains("\\t2"))
                        ProcessaTotalIP("192.168.0.172", 2);
                    System.Threading.Thread.Sleep(60000);
                }
            else 
                Console.WriteLine(@"
\g          Importa CDR Gennex
\t1         Importa TotalIP Servidor 172.16.20.4    - 19
\t2         Importa TotalIP Servidor 192.168.0.172  - 190
\?          Help
");
        }

        private static void ProcessaTotalIP(string serverIP, int serverId)
        {
            Int64 ultimoId = Convert.ToInt64(System.IO.File.ReadAllText("ultimoIdTotalIP_"+serverIP+".txt"));

            Console.WriteLine(DateTime.Now + "- Consultando registros no TotalIP");
            List<DTO.TotalIP.ligacoes_ativo> ligs = new BLL.TotalIP.ligacoes_ativo().getTarifa(serverIP, ultimoId);

            BLL.Link linkService = new BLL.Link(serverId);
            BLL.Tarifa tarifaService = new BLL.Tarifa();
            BLL.Operadora operadoraService = new BLL.Operadora();
            BLL.Campanha campanhaService = new BLL.Campanha();
            BLL.LigacaoStatus ligacaoStatusService = new BLL.LigacaoStatus();
            BLL.Calculo calculo = new BLL.Calculo();
            for (int i = 0; i < ligs.Count; i++)
            {
                var lig = ligs[i];
                DTO.Link link = linkService.SelectByIdentificador(lig.nome_rota).FirstOrDefault();
                DTO.Operadora operadora = operadoraService.SelectById(link.OperadoraId);
                DTO.Tarifa tarifa = tarifaService.SelectById(operadora.TarifaId);
                DTO.LigacaoStatus ligacaoStatus = ligacaoStatusService.SelectByDescription(lig.status).FirstOrDefault();
                if (ligacaoStatus == null)
                {
                    ligacaoStatusService.Cadastro(new DTO.LigacaoStatus()
                    {
                        Descricao = lig.status
                    });
                    ligacaoStatus = ligacaoStatusService.SelectByDescription(lig.status).FirstOrDefault();
                }
                DTO.Campanha campanha = campanhaService.SelectByIdNoDiscador(lig.id_campanha, serverId);
                if (campanha == null)
                {
                    campanhaService.Cadastro(new DTO.Campanha()
                    {
                        CampanhaIdNoDiscador = lig.id_campanha,
                        Descricao = lig.id_campanha.ToString(),
                        DiscadorId = serverId,
                        CarteiraId = 1
                    });
                    campanha = campanhaService.SelectByIdNoDiscador(lig.id_campanha, serverId);
                }

                DTO.Bilhete bilhete = new DTO.Bilhete();

                if(lig.billing != 0)
                    bilhete.AtendimentoPublica = lig.data.AddSeconds(lig.duracao).AddSeconds(-lig.billing);
                bilhete.CallerIdDiscador = lig.uniqueid;
                bilhete.CampanhaId = campanha.CampanhaId;
                bilhete.Cliente = "[Não Informado]";
                bilhete.CodNoDiscador = lig.id;
                bilhete.Data = lig.data;
                bilhete.DataInicio = lig.data;
                bilhete.DDI = 55;
                bilhete.DiscadorId = serverId;
                bilhete.Duracao = lig.billing;
                bilhete.FimLigacao = lig.data.AddSeconds(lig.duracao);
                bilhete.LigacaoStatusId = ligacaoStatus.LigacaoStatusId;
                bilhete.LinkId = link.LinkId;
                bilhete.OperadoraId = operadora.OperadoraId;
                bilhete.TarifaId = tarifa.TarifaId;
                switch (lig.destino.Length)
                {
                    case 8:
                    case 9:
                        bilhete.DDD = 11;
                        bilhete.Telefone = Convert.ToInt64(lig.destino);
                        break;

                    case 11:
                    case 12:
                        bilhete.DDD = Convert.ToInt32(lig.destino.Substring(0, 3));
                        bilhete.Telefone = Convert.ToInt64(lig.destino.Substring(3));
                        break;

                    case 13:
                    case 14:
                        bilhete.DDD = Convert.ToInt32(lig.destino.Substring(2, 2));
                        bilhete.Telefone = Convert.ToInt64(lig.destino.Substring(4));
                        break;
                }

                bilhete.Valor = calculo.calcular(bilhete, tarifa);
                new BLL.Bilhete().Cadastro(bilhete);

                ultimoId = lig.id;
                System.IO.File.WriteAllText("ultimoIdTotalIP_" + serverIP + ".txt", (ultimoId+1).ToString());
                if (i % 10 == 0)
                    Console.WriteLine(DateTime.Now + "- importado " + i + " de " + ligs.Count + " (" + lig.data + ")");
            }
            Console.WriteLine(DateTime.Now + "- Termino Consulta");
        }

        private static void ProcessaGennex()
        {
            Int64 ultimoId = Convert.ToInt64(System.IO.File.ReadAllText("ultimoIdGennex.txt"));

            Console.WriteLine(DateTime.Now + "- Consultando registros no Gennex");
            List<DTO.Gennex.CDR> cdrs = new BLL.Gennex.CDR().getTarifa(ultimoId).OrderBy(c => c.CodNoDiscador).ToList();

            Console.WriteLine(DateTime.Now + "- Consultando Links");
            BLL.Link service = new BLL.Link(3);
            BLL.Tarifa tarifaService = new BLL.Tarifa();
            BLL.Operadora operadoraService = new BLL.Operadora();
            BLL.Campanha campanhaService = new BLL.Campanha();
            BLL.LigacaoStatus ligacaoStatusService = new BLL.LigacaoStatus();
            BLL.Calculo calculo = new BLL.Calculo();
            for (int i = 0; i < cdrs.Count; i++)
            {
                var cdr = cdrs[i];

                if (cdr.LinkId == "Link Manual" ||
                    cdr.LinkId == "Interligacao")
                    continue;

                DTO.Link link = service.SelectByIdentificador(cdr.LinkId).FirstOrDefault();
                DTO.Bilhete bilhete = new DTO.Bilhete();
                bilhete.AtendimentoPublica = cdr.AtendimentoPublica;
                bilhete.CallerIdDiscador = cdr.CallerIdDiscador;
                bilhete.Cliente = cdr.Cliente;
                bilhete.CodNoDiscador = cdr.CodNoDiscador;
                bilhete.Data = DateTime.Now;
                bilhete.DataInicio = cdr.DataInicio;
                bilhete.DDD = cdr.DDD;
                bilhete.DDI = cdr.DDI;
                bilhete.DiscadorId = link.DiscadorId;
                bilhete.Duracao = cdr.Duracao;
                bilhete.FimLigacao = cdr.FimLigacao;

                DTO.LigacaoStatus ligacaoStatus = ligacaoStatusService.SelectByDescription(cdr.LigacaoStatusId).FirstOrDefault();
                if (ligacaoStatus == null)
                {
                    ligacaoStatusService.Cadastro(new DTO.LigacaoStatus()
                    {
                        Descricao = cdr.LigacaoStatusId.ToString()
                    });
                    ligacaoStatus = ligacaoStatusService.SelectByDescription(cdr.LigacaoStatusId).FirstOrDefault();
                }
                bilhete.LigacaoStatusId = ligacaoStatus.LigacaoStatusId;

                // bilhete.LigacaoStatusId
                bilhete.LinkId = link.LinkId;
                bilhete.OperadoraId = link.OperadoraId;
                bilhete.RingOperadora = cdr.RingOperadora;

                DTO.Operadora operadora = operadoraService.SelectById(link.OperadoraId);
                DTO.Tarifa tarifa = tarifaService.SelectById(operadora.TarifaId);

                bilhete.TarifaId = tarifa.TarifaId;
                bilhete.Telefone = cdr.Telefone;
                bilhete.Valor = calculo.calcular(bilhete, tarifa);

                DTO.Campanha campanha = campanhaService.SelectByIdNoDiscador(cdr.CampanhaId, 3);
                if (campanha == null)
                {
                    campanhaService.Cadastro(new DTO.Campanha()
                    {
                        CampanhaIdNoDiscador = cdr.CampanhaId,
                        Descricao = cdr.CampanhaId.ToString(),
                        DiscadorId = 3,
                        CarteiraId = 1
                    });
                    campanha = campanhaService.SelectByIdNoDiscador(cdr.CampanhaId, 3);
                }
                bilhete.CampanhaId = campanha.CampanhaId;
                if(bilhete.Valor > 0)
                new BLL.Bilhete().Cadastro(bilhete);

                ultimoId = cdr.CodNoDiscador;
                System.IO.File.WriteAllText("ultimoIdGennex.txt", ultimoId.ToString());
                if (i % 10 == 0)
                    Console.WriteLine(DateTime.Now + "- importado " + i + " de " + cdrs.Count + " (" + cdr.DataInicio + ")");
            }
            Console.WriteLine(DateTime.Now + "- Termino Consulta");
        }
    }
}
