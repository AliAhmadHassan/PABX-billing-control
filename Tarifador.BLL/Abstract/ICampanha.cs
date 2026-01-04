using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifador.BLL.Abstract
{
    public interface ICampanha:IBase<DTO.Campanha>
    {
		List<DTO.Campanha> SelectByDiscadorId(int DiscadorId);
		List<DTO.Campanha> SelectByCarteiraId(int CarteiraId);
    }
}