using Tarifador.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifador.BLL
{
    public class Campanha:ICampanha
    {
        public List<DTO.Campanha> Select()
        {
            return new DAL.Campanha().Select();
        }

        SortedList<int, DTO.Campanha> indexador = new SortedList<int, DTO.Campanha>();

        public DTO.Campanha SelectById(int Id)
        {
            if (!indexador.ContainsKey(Id))
            {
                DTO.Campanha campanha = new DAL.Campanha().SelectById(Id);
                if (campanha.CampanhaId == -1)
                    return null;

                indexador.Add(Id, campanha);
            }
            return indexador[Id];

            
        }

        SortedList<int, DTO.Campanha> indexadorNoDiscador = new SortedList<int, DTO.Campanha>();

        public DTO.Campanha SelectByIdNoDiscador(int Id, int DiscadorId)
        {
            if (!indexadorNoDiscador.ContainsKey(Id))
            {
                DTO.Campanha campanha = new DAL.Campanha().SPSCampanhaByCampanhaIdNoDiscador(Id, DiscadorId);
                if (campanha.CampanhaId == -1)
                    return null;

                indexadorNoDiscador.Add(Id, campanha);
            }
            return indexadorNoDiscador[Id];


        }

        public void Remover(DTO.Campanha Entidade)
        {
            new DAL.Campanha().Remover(Entidade);
        }

        public void Cadastro(DTO.Campanha Entidade)
        {
            new DAL.Campanha().Cadastro(Entidade);
        }

        public List<DTO.Campanha> SelectByDiscadorId(int DiscadorId)
        {
            return new DAL.Campanha().SelectByDiscadorId(DiscadorId);
        }

        public List<DTO.Campanha> SelectByCarteiraId(int CarteiraId)
        {
            return new DAL.Campanha().SelectByCarteiraId(CarteiraId);
        }
    }
}
