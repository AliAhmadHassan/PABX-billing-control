using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Tarifador.DAL
{
    public class Operadora:Base<DTO.Operadora>
    {
        public List<DTO.Operadora> SelectByTarifaId(int TarifaId)
        {
            return AuxConsultas<DTO.Operadora>.Lista("SPSOperadoraByTarifaId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@TarifaId", TarifaId));
        }
    }
}
