using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConciliaContas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Carregando: " + args[0]);

            string[] linhas = System.IO.File.ReadAllLines(args[0]);

            Tarifador.BLL.Gennex.CDR cdrService = new Tarifador.BLL.Gennex.CDR();
            List<Tarifador.DTO.Operadora> operadoras = new Tarifador.BLL.Operadora().Select();
            List<Tarifador.DTO.Tarifa> tarifas = new Tarifador.BLL.Tarifa().Select();
            Tarifador.BLL.Calculo calculo = new Tarifador.BLL.Calculo();

            linhas[9] += "At Publica;Fim;Duracao;";

            foreach (var item in operadoras)
                linhas[9] += item.Descricao + ";";

            for (int i = 10; i < linhas.Length; i++)
            {
                string[] separado = linhas[i].Split(';');

                if (separado[8] != "Não Encontrado Ligação") {
                    //Console.WriteLine(i + " OK;");
                    continue;
                }
                else
                {
                    linhas[i] = linhas[i].Replace("Não Encontrado Ligação;", "");
                    separado = linhas[i].Split(';');
                }

                int dDD = Convert.ToInt32(separado[2].Substring(2, 2));
                Int64 telefone = Convert.ToInt64(separado[2].Substring(4));
                DateTime data = Convert.ToDateTime(separado[0]);

                List<Tarifador.DTO.Gennex.CDR> cdrs = cdrService.getByDDDTelefoneDate(dDD, telefone, data, -5, +5);

                //if (cdrs.Count > 1)
                //{
                //    for (int j = 0; j <= 9; j++)
                //    {
                //        cdrs = cdrService.getByDDDTelefoneDate(dDD, telefone, data, -149 + j*15, +21 - j*2);
                //        if (cdrs.Count == 1)
                //            break;
                //    }
                //}
                int iTentativas = 1;
                if (cdrs.Count == 0)
                {
                    int tolaranciaFinal = (int)Math.Exp(((double)13) / 2);
                    List<Tarifador.DTO.Gennex.CDR> cdrsAnterior = null;
                    for (int j = 12; j >= 0; j--)
                    {
                        int tolaranciaInicial = (int)Math.Exp(((double)j) / 2);


                        cdrs = cdrService.getByDDDTelefoneDate(dDD, telefone, data, -tolaranciaFinal, -tolaranciaInicial);
                        
                        if (cdrs.Count == 1)
                            break;

                        if (cdrs.Count > 1)
                            cdrsAnterior = cdrs;

                        cdrs = cdrService.getByDDDTelefoneDate(dDD, telefone, data, tolaranciaInicial, tolaranciaFinal);

                        if (cdrs.Count == 1) 
                            break;

                        if (cdrs.Count > 1)
                            cdrsAnterior = cdrs;


                        tolaranciaFinal = tolaranciaInicial;
                        iTentativas++;

                        System.Threading.Thread.Sleep(1000);
                    }

                    if (cdrs.Count == 0 && cdrsAnterior != null)
                        cdrs = cdrsAnterior;

                }

                //if (cdrs.Count == 0)
                //{
                //    int tolaranciaFinal = -5;
                //    for (int j = 1; j <= 13; j++)
                //    {
                //        int tolaranciaInicial = (int)Math.Exp(((double)j) / 2);
                        

                //        cdrs = cdrService.getByDDDTelefoneDate(dDD, telefone, data, tolaranciaFinal, tolaranciaInicial);

                //        if (cdrs.Count >= 1)
                //            break;

                //        tolaranciaFinal = tolaranciaInicial;
                //    }

                //}


                if (cdrs.Count == 0)
                {
                    linhas[i] += "Não Encontrado Ligação;";
                    Console.WriteLine("Não Encontrado Ligação;");
                    continue;
                }




                Tarifador.DTO.Gennex.CDR cdr = cdrs.FirstOrDefault();

                if (cdrs.Count != 1)
                    Console.WriteLine("Encontrado " + cdrs.Count + " Duração : " + separado[3] + " Tempo " + ((decimal)cdr.Duracao/60));


                Tarifador.DTO.Bilhete bilhete = new Tarifador.DTO.Bilhete();

                bilhete.AtendimentoPublica = cdr.AtendimentoPublica;
                bilhete.CallerIdDiscador = cdr.CallerIdDiscador;
                bilhete.Cliente = cdr.Cliente;
                bilhete.CodNoDiscador = cdr.CodNoDiscador;
                bilhete.Data = DateTime.Now;
                bilhete.DataInicio = cdr.DataInicio;
                bilhete.DDD = cdr.DDD;
                bilhete.DDI = cdr.DDI;
                bilhete.Duracao = cdr.Duracao;
                bilhete.FimLigacao = cdr.FimLigacao;
                bilhete.RingOperadora = cdr.RingOperadora;
                bilhete.Telefone = cdr.Telefone;

                linhas[i] += bilhete.AtendimentoPublica + ";";
                linhas[i] += bilhete.FimLigacao + ";";
                linhas[i] += bilhete.Duracao + ";";

                foreach (var item in operadoras)
                {
                    Tarifador.DTO.Tarifa tarifa = tarifas.Where(c => c.TarifaId.Equals(item.TarifaId)).FirstOrDefault();
                    bilhete.Valor = calculo.calcular(bilhete, tarifa);
                    linhas[i] += bilhete.Valor + ";";
                }

                


                //if(i%10 == 0)
                    Console.WriteLine("Processado "+i+" de " + linhas.Length + " Tentativa: " + iTentativas);
            }

            System.IO.File.WriteAllLines("Resultado.csv", linhas);
        }
    }
}
