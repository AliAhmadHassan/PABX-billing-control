using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL.Abstract
{
    public interface IOperadora:IBase<DTO.Operadora>
    {
		List<DTO.Operadora> SelectByTarifaId(int TarifaId);
    }
}