using Tarifador.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifador.BLL
{
    public class Carteira:ICarteira
    {
        public List<DTO.Carteira> Select()
        {
            return new DAL.Carteira().Select();
        }

        public DTO.Carteira SelectById(int Id)
        {
            return new DAL.Carteira().SelectById(Id);
        }

        public void Remover(DTO.Carteira Entidade)
        {
            new DAL.Carteira().Remover(Entidade);
        }

        public void Cadastro(DTO.Carteira Entidade)
        {
            new DAL.Carteira().Cadastro(Entidade);
        }
    }
}
