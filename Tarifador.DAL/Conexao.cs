using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tarifador.DAL
{
    public class Conexao
    {
        private string ConnectionStringCore = "Data Source=192.168.2.166;Initial Catalog=TarifadorDB;Persist Security Info=True;User ID=sa;Password=sistema123*";

        protected string strConn(DTO.Base.TipoConexao tipoConexao)
        {
            string ConnectionString = string.Empty;

            switch (tipoConexao)
            {
                case DTO.Base.TipoConexao.Core:
                    ConnectionString = ConnectionStringCore;
                    break;
            }
            return ConnectionString;
        }

    }
}
