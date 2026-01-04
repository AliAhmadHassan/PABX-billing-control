using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL.Abstract
{
    public interface IBilhete:IBase<DTO.Bilhete>
    {
		List<DTO.Bilhete> SelectByDiscadorId(int DiscadorId);
		List<DTO.Bilhete> SelectByTarifaId(int TarifaId);
		List<DTO.Bilhete> SelectByLigacaoStatusId(int LigacaoStatusId);
		List<DTO.Bilhete> SelectByLinkId(int LinkId);
		List<DTO.Bilhete> SelectByOperadoraId(int OperadoraId);
    }
}