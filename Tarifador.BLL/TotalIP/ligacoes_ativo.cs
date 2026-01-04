using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifador.BLL.TotalIP
{
    public class ligacoes_ativo
    {
        public List<DTO.TotalIP.ligacoes_ativo> getTarifa(string ipServer, Int64 ultimoId)
        {
            return new DAL.TotalIP.ligacoes_ativo().getTarifa(ipServer, ultimoId);
        }
    }
}
