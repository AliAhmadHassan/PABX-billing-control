using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL.Gennex
{
    public class CDR
    {
        new DAL.Gennex.CDR cdrDAL = null;
        public CDR() {
            cdrDAL = new DAL.Gennex.CDR();
        }

        public List<DTO.Gennex.CDR> getTarifa(Int64 ultimoId = 1000)
        {
            return cdrDAL.getTarifa(ultimoId);
        }
        public List<DTO.Gennex.CDR> getByDDDTelefoneDate(int dDD, Int64 Telefone, DateTime dataInicio, int toleranciaInicial, int toleranciaFinal)
        {
            return cdrDAL.getByDDDTelefoneDate(dDD, Telefone, dataInicio, toleranciaInicial, toleranciaFinal);
        }
    }
}
