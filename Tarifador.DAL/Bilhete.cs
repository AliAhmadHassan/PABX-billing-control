using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifador.DAL
{
    public class Bilhete:Base<DTO.Bilhete>
    {
        public List<DTO.Bilhete> SelectByDiscadorId(int DiscadorId)
        {
            return AuxConsultas<DTO.Bilhete>.Lista("SPSBilheteByDiscadorId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@DiscadorId", DiscadorId));
        }
        public List<DTO.Bilhete> SelectByTarifaId(int TarifaId)
        {
            return AuxConsultas<DTO.Bilhete>.Lista("SPSBilheteByTarifaId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@TarifaId", TarifaId));
        }
        public List<DTO.Bilhete> SelectByLigacaoStatusId(int LigacaoStatusId)
        {
            return AuxConsultas<DTO.Bilhete>.Lista("SPSBilheteByLigacaoStatusId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@LigacaoStatusId", LigacaoStatusId));
        }
        public List<DTO.Bilhete> SelectByLinkId(int LinkId)
        {
            return AuxConsultas<DTO.Bilhete>.Lista("SPSBilheteByLinkId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@LinkId", LinkId));
        }
        public List<DTO.Bilhete> SelectByOperadoraId(int OperadoraId)
        {
            return AuxConsultas<DTO.Bilhete>.Lista("SPSBilheteByOperadoraId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@OperadoraId", OperadoraId));
        }
        public List<DTO.Bilhete> SelectByCampanhaId(int CampanhaId)
        {
            return AuxConsultas<DTO.Bilhete>.Lista("SPSBilheteByCampanhaId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CampanhaId", CampanhaId));
        }
    }
}
