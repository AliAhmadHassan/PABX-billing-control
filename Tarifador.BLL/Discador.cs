using Tarifador.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL
{
    public class Discador:IDiscador
    {
        public List<DTO.Discador> Select()
        {
            return new DAL.Discador().Select();
        }

        public DTO.Discador SelectById(int Id)
        {
            return new DAL.Discador().SelectById(Id);
        }

        public void Remover(DTO.Discador Entidade)
        {
            new DAL.Discador().Remover(Entidade);
        }

        public void Cadastro(DTO.Discador Entidade)
        {
            new DAL.Discador().Cadastro(Entidade);
        }
    }
}
