using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifador.DAL
{
    public class Campanha:Base<DTO.Campanha>
    {
        public List<DTO.Campanha> SelectByDiscadorId(int DiscadorId)
        {
            return AuxConsultas<DTO.Campanha>.Lista("SPSCampanhaByDiscadorId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@DiscadorId", DiscadorId));
        }
        public List<DTO.Campanha> SelectByCarteiraId(int CarteiraId)
        {
            return AuxConsultas<DTO.Campanha>.Lista("SPSCampanhaByCarteiraId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CarteiraId", CarteiraId));
        }
        public DTO.Campanha SPSCampanhaByCampanhaIdNoDiscador(int CarteiraId, int DiscadorId)
        {
            return AuxConsultas<DTO.Campanha>.Entidade("SPSCampanhaByCampanhaIdNoDiscador", strConn(DTO.Base.TipoConexao.Core), 
                new SqlParameter[] {
                    new SqlParameter("@CampanhaIdNoDiscador", CarteiraId),
                    new SqlParameter("@DiscadorId", DiscadorId)
                });
        }
    }
}
