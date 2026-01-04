using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL.Abstract
{
    public interface ILink:IBase<DTO.Link>
    {
		List<DTO.Link> SelectByDiscadorId(int DiscadorId);
        List<DTO.Link> SelectByIdentificador(string Indentificador);
    }
}