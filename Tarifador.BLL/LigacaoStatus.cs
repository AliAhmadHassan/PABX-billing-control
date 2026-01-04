using Tarifador.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL
{
    public class LigacaoStatus:ILigacaoStatus
    {
        public List<DTO.LigacaoStatus> Select()
        {
            return new DAL.LigacaoStatus().Select();
        }

        SortedList<int, DTO.LigacaoStatus> indexador = new SortedList<int, DTO.LigacaoStatus>();
        public DTO.LigacaoStatus SelectById(int Id)
        {
            if (!indexador.ContainsKey(Id))
            {
                DTO.LigacaoStatus aux = new DAL.LigacaoStatus().SelectById(Id);
                if (aux == null)
                    return null;

                indexador.Add(Id, aux);
            }
            return indexador[Id];


        }

        public void Remover(DTO.LigacaoStatus Entidade)
        {
            new DAL.LigacaoStatus().Remover(Entidade);
        }

        public void Cadastro(DTO.LigacaoStatus Entidade)
        {
            new DAL.LigacaoStatus().Cadastro(Entidade);
        }

        SortedList<string, List<DTO.LigacaoStatus>> indexador2 = new SortedList<string, List<DTO.LigacaoStatus>>();
        public List<DTO.LigacaoStatus> SelectByDescription(string description)
        {
            if (!indexador2.ContainsKey(description) || indexador2[description].Count == 0)
            {
                List<DTO.LigacaoStatus> aux = new DAL.LigacaoStatus().SelectByDescription(description);
                if (indexador2.ContainsKey(description))
                    indexador2[description] = aux;
                else
                indexador2.Add(description, aux);
            }
            return indexador2[description];
        }
    }
}
