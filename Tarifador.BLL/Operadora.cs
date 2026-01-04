using Tarifador.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL
{
    public class Operadora:IOperadora
    {
        public List<DTO.Operadora> Select()
        {
            return new DAL.Operadora().Select();
        }

        SortedList<int, DTO.Operadora> indexador = new SortedList<int, DTO.Operadora>();
        public DTO.Operadora SelectById(int Id)
        {
            if (!indexador.ContainsKey(Id))
                indexador.Add(Id, new DAL.Operadora().SelectById(Id));
            return indexador[Id];
        }

        public void Remover(DTO.Operadora Entidade)
        {
            new DAL.Operadora().Remover(Entidade);
        }

        public void Cadastro(DTO.Operadora Entidade)
        {
            new DAL.Operadora().Cadastro(Entidade);
        }

        public List<DTO.Operadora> SelectByTarifaId(int TarifaId)
        {
            return new DAL.Operadora().SelectByTarifaId(TarifaId);
        }
    }
}
