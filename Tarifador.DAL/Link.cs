using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Tarifador.DAL
{
    public class Link:Base<DTO.Link>
    {
        public List<DTO.Link> SelectByDiscadorId(int DiscadorId)
        {
            return AuxConsultas<DTO.Link>.Lista("SPSLinkByDiscadorId", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@DiscadorId", DiscadorId));
        }

        public List<DTO.Link> SelectByIdentificador(string Indentificador, int discadorId)
        {
            return AuxConsultas<DTO.Link>.Lista("SPSLinkByIndentificador", strConn(DTO.Base.TipoConexao.Core), 
                new SqlParameter[]{
                new SqlParameter("@Indentificador", Indentificador) ,
                new SqlParameter("@DiscadorId", discadorId)
                });
        }
    }
}
