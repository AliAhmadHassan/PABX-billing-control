using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL.Abstract
{
    public interface ITarifa:IBase<DTO.Tarifa>
    {
		List<DTO.Tarifa> SelectByCadLoc(int CadLoc);
		List<DTO.Tarifa> SelectByCarLDN(int CarLDN);
		List<DTO.Tarifa> SelectByCadLDE(int CadLDE);
		List<DTO.Tarifa> SelectByCadVC1(int CadVC1);
		List<DTO.Tarifa> SelectByCadVC2(int CadVC2);
		List<DTO.Tarifa> SelectByCadVC3(int CadVC3);
    }
}