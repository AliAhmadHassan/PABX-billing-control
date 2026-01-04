using Tarifador.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL
{
    public class Cadencia:ICadencia
    {
        public List<DTO.Cadencia> Select()
        {
            return new DAL.Cadencia().Select();
        }

        SortedList<int, DTO.Cadencia> indexador = new SortedList<int, DTO.Cadencia>();
        public DTO.Cadencia SelectById(int Id)
        {
            if (!indexador.ContainsKey(Id))
                indexador.Add(Id, new DAL.Cadencia().SelectById(Id));
            return indexador[Id];
        }

        public void Remover(DTO.Cadencia Entidade)
        {
            new DAL.Cadencia().Remover(Entidade);
        }

        public void Cadastro(DTO.Cadencia Entidade)
        {
            new DAL.Cadencia().Cadastro(Entidade);
        }
    }
}
