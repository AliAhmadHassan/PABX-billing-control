using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifador.DAL.TotalIP
{
    public class ligacoes_ativo
    {
        public List<DTO.TotalIP.ligacoes_ativo> getTarifa(string ipServer, Int64 ultimoId)
        {
            List<DTO.TotalIP.ligacoes_ativo> retorno = new List<DTO.TotalIP.ligacoes_ativo>();

            string connstring = String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["TotalIPDataBaseConnectionString"].ConnectionString,
                ipServer);

            using (NpgsqlConnection conn = new NpgsqlConnection(connstring))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(@"
                        SELECT id, destino, duracao, billing, status, ramal, data, tipo_ligacao, custo, custo_total, custo_arredondado, billing_arredondado, filial, uniqueid, id_campanha, id_rota, nome_rota
                        FROM public.ligacoes_ativo
                        where id between " + ultimoId + @" and " + ultimoId + @" + 10000 
                        order by id 
                        ", conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        int i = 0;
                        Console.WriteLine("Carregando ");
                        while (dr.Read())
                        {
                            if (dr["duracao"] == DBNull.Value
                                || dr["id_campanha"] == DBNull.Value)
                                continue;
                            DTO.TotalIP.ligacoes_ativo lig = new DTO.TotalIP.ligacoes_ativo();
                            lig.id = Convert.ToInt32(dr["id"]);
                            lig.destino = Convert.ToString(dr["destino"]);
                            lig.duracao = Convert.ToInt32(dr["duracao"]);
                            lig.billing = Convert.ToInt32(dr["billing"]);
                            lig.status = Convert.ToString(dr["status"]);
                            lig.ramal = Convert.ToString(dr["ramal"]);
                            lig.data = Convert.ToDateTime(dr["data"]);
                            lig.tipo_ligacao = Convert.ToString(dr["tipo_ligacao"]);
                            lig.custo = Convert.ToDecimal(dr["custo"]);
                            if(dr["custo_total"] != DBNull.Value)
                            lig.custo_total = Convert.ToDecimal(dr["custo_total"]);
                            if (dr["custo_arredondado"] != DBNull.Value)
                                lig.custo_arredondado = Convert.ToDecimal(dr["custo_arredondado"]);
                            if (dr["billing_arredondado"] != DBNull.Value)
                                lig.billing_arredondado = Convert.ToInt32(dr["billing_arredondado"]);
                            lig.filial = Convert.ToString(dr["filial"]);
                            lig.uniqueid = Convert.ToString(dr["uniqueid"]);
                            lig.id_campanha = Convert.ToInt32(dr["id_campanha"]);
                            lig.id_rota = Convert.ToInt32(dr["id_rota"]);
                            lig.nome_rota = Convert.ToString(dr["nome_rota"]);
                            if (lig.nome_rota.ToLower().Contains("chip"))
                                lig.nome_rota = "EBS CHIP";


                            retorno.Add(lig);
                            if (i % 10 == 0)
                                Console.Write("\t" + i);
                            i++;
                        }
                    }
                }
            }
            return retorno;
        }
    }
}
