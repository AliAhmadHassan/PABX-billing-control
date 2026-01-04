using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Tarifador.DAL
{
    public class Tarifa:Base<DTO.Tarifa>
    {
        public List<DTO.Tarifa> SelectByCadLoc(int CadLoc)
        {
            return AuxConsultas<DTO.Tarifa>.Lista("SPSTarifaByCadLoc", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CadLoc", CadLoc));
        }
        public List<DTO.Tarifa> SelectByCarLDN(int CarLDN)
        {
            return AuxConsultas<DTO.Tarifa>.Lista("SPSTarifaByCarLDN", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CarLDN", CarLDN));
        }
        public List<DTO.Tarifa> SelectByCadLDE(int CadLDE)
        {
            return AuxConsultas<DTO.Tarifa>.Lista("SPSTarifaByCadLDE", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CadLDE", CadLDE));
        }
        public List<DTO.Tarifa> SelectByCadVC1(int CadVC1)
        {
            return AuxConsultas<DTO.Tarifa>.Lista("SPSTarifaByCadVC1", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CadVC1", CadVC1));
        }
        public List<DTO.Tarifa> SelectByCadVC2(int CadVC2)
        {
            return AuxConsultas<DTO.Tarifa>.Lista("SPSTarifaByCadVC2", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CadVC2", CadVC2));
        }
        public List<DTO.Tarifa> SelectByCadVC3(int CadVC3)
        {
            return AuxConsultas<DTO.Tarifa>.Lista("SPSTarifaByCadVC3", strConn(DTO.Base.TipoConexao.Core), new SqlParameter("@CadVC3", CadVC3));
        }
    }
}
