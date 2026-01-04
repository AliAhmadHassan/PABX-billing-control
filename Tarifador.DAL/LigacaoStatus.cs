using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Tarifador.DAL
{
    public class LigacaoStatus:Base<DTO.LigacaoStatus>
    {
        public List<DTO.LigacaoStatus> SelectByDescription(string description)
        {
            return AuxConsultas<DTO.LigacaoStatus>.Lista("SPSLigacaoStatusBydescription", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@Descricao", description));
        }
    }
}
