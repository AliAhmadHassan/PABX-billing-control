using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Tarifador.DAL.Gennex
{
    public class CDR
    {
        public List<DTO.Gennex.CDR> getTarifa(Int64 ultimoId = 1000)
        {
            List<DTO.Gennex.CDR> cdrs = new List<DTO.Gennex.CDR>();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GennexDataBaseConnectionString"].ConnectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(@"
                        SELECT cdr.CDR_DH_INICIO as DataInicio, cdr.TAR_SEGUNDOS as Duracao, cdr.ID_CDR as CodNoDiscador, cdr.CDR_CALLID as CallerIdDiscador
	                        , cdr.CDR_CHAVE as Cliente, cdr.ID_DDI as DDI, cdr.id_ddd as DDD, cdr.CDR_FONE as Telefone, cdr.CDR_DH_AT_PUBLICA as AtendimentoPublica
                            , cdr.CDR_DH_FIMLIGACAO as FimLigacao, cdr.CDR_DH_RINGOPERADORA RingOperadora, st_fim.STF_DESC as LigacaoStatusId
                            , operadora.OPE_DESC as LinkId, cdr.ID_CAMPANHA as CampanhaId
                        FROM orcozol.cdr
	                        inner join st_fim on st_fim.ID_STFIM = cdr.ID_STFIM
                            inner join operadora on operadora.ID_OPERADORA = cdr.ID_OPERADORA
                        where cdr.ID_CDR between " + ultimoId + " and "+ultimoId +" + 10000" +
                        " and cdr.Id_CDR < 91310596", conn))
                {//103535560
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        int i = 0;
                        Console.WriteLine("Carregando ");
                        while (dr.Read())
                        {
                            DTO.Gennex.CDR cdr = new DTO.Gennex.CDR();
                            cdr.DataInicio = Convert.ToDateTime(dr["DataInicio"]);
                            cdr.Duracao = Convert.ToInt32(dr["Duracao"]);
                            cdr.CodNoDiscador = Convert.ToInt64(dr["CodNoDiscador"]);
                            cdr.CallerIdDiscador = Convert.ToString(dr["CallerIdDiscador"]);
                            cdr.Cliente = Convert.ToString(dr["Cliente"]);
                            cdr.DDI = Convert.ToInt32(dr["DDI"]);
                            cdr.DDD = Convert.ToInt32(dr["DDD"]);
                            if (Convert.ToString(dr["Telefone"]) == "ASTERISK")
                                continue;
                            cdr.Telefone = Convert.ToInt64(dr["Telefone"]);
                            try { cdr.AtendimentoPublica = Convert.ToDateTime(dr["AtendimentoPublica"]); } catch { }

                            try
                            { cdr.FimLigacao = Convert.ToDateTime(dr["FimLigacao"]);
                            }
                            catch { }
                            try
                                { cdr.RingOperadora = Convert.ToDateTime(dr["RingOperadora"]); }
                            catch { }
                            cdr.LigacaoStatusId = Convert.ToString(dr["LigacaoStatusId"]);
                            cdr.LinkId = Convert.ToString(dr["LinkId"]);
                            cdr.CampanhaId = Convert.ToInt32(dr["CampanhaId"]);
                            cdrs.Add(cdr);
                            if(i%10 == 0)
                                Console.Write("\t" + i);
                            i++;
                        }
                    }
                }
                
            }
            return cdrs;
        }
        public List<DTO.Gennex.CDR> getByDDDTelefoneDate(int dDD, Int64 Telefone, DateTime dataInicio,int toleranciaInicial, int toleranciaFinal)
        {
            List<DTO.Gennex.CDR> cdrs = new List<DTO.Gennex.CDR>();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GennexDataBaseConnectionString"].ConnectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(@"
                        SELECT cdr.CDR_DH_INICIO as DataInicio, cdr.TAR_SEGUNDOS as Duracao, cdr.ID_CDR as CodNoDiscador, cdr.CDR_CALLID as CallerIdDiscador
	                        , cdr.CDR_CHAVE as Cliente, cdr.ID_DDI as DDI, cdr.id_ddd as DDD, cdr.CDR_FONE as Telefone, cdr.CDR_DH_AT_PUBLICA as AtendimentoPublica
                            , cdr.CDR_DH_FIMLIGACAO as FimLigacao, cdr.CDR_DH_RINGOPERADORA RingOperadora, st_fim.STF_DESC as LigacaoStatusId
                            , operadora.OPE_DESC as LinkId, cdr.ID_CAMPANHA as CampanhaId
                        FROM orcozol.cdr
	                        inner join st_fim on st_fim.ID_STFIM = cdr.ID_STFIM
                            inner join operadora on operadora.ID_OPERADORA = cdr.ID_OPERADORA
                        where cdr.cdr_fone = '" + Telefone.ToString() + "' and ID_DDD = '" + dDD.ToString() + "'" +
                        " and cdr.CDR_DH_INICIO between '"+ dataInicio.AddSeconds(toleranciaInicial).ToString("yyyy-MM-dd HH:mm:ss") + "' and '"+ dataInicio.AddSeconds(toleranciaFinal).ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                        " order by datainicio desc", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (dr.Read())
                        {
                            DTO.Gennex.CDR cdr = new DTO.Gennex.CDR();
                            cdr.DataInicio = Convert.ToDateTime(dr["DataInicio"]);
                            cdr.Duracao = Convert.ToInt32(dr["Duracao"]);
                            cdr.CodNoDiscador = Convert.ToInt64(dr["CodNoDiscador"]);
                            cdr.CallerIdDiscador = Convert.ToString(dr["CallerIdDiscador"]);
                            cdr.Cliente = Convert.ToString(dr["Cliente"]);
                            cdr.DDI = Convert.ToInt32(dr["DDI"]);
                            cdr.DDD = Convert.ToInt32(dr["DDD"]);
                            if (Convert.ToString(dr["Telefone"]) == "ASTERISK")
                                continue;
                            cdr.Telefone = Convert.ToInt64(dr["Telefone"]);
                            try { cdr.AtendimentoPublica = Convert.ToDateTime(dr["AtendimentoPublica"]); } catch { }

                            try
                            {
                                cdr.FimLigacao = Convert.ToDateTime(dr["FimLigacao"]);
                            }
                            catch { }
                            try
                            { cdr.RingOperadora = Convert.ToDateTime(dr["RingOperadora"]); }
                            catch { }
                            cdr.LigacaoStatusId = Convert.ToString(dr["LigacaoStatusId"]);
                            cdr.LinkId = Convert.ToString(dr["LinkId"]);
                            cdr.CampanhaId = Convert.ToInt32(dr["CampanhaId"]);
                            cdrs.Add(cdr);
                            i++;
                        }
                    }
                }

            }
            return cdrs;
        }
    }
}
