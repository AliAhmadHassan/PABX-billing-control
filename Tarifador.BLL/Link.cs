using Tarifador.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL
{
    public class Link:ILink
    {
        DAL.Link service;
        int discadorId;
        public Link(int discadorId)
        {
            service = new DAL.Link() ;
            this.discadorId = discadorId;
        }
        public List<DTO.Link> Select()
        {
            return service.Select();
        }

        public DTO.Link SelectById(int Id)
        {
            return service.SelectById(Id);
        }

        public void Remover(DTO.Link Entidade)
        {
            service.Remover(Entidade);
        }

        public void Cadastro(DTO.Link Entidade)
        {
            service.Cadastro(Entidade);
        }

        public List<DTO.Link> SelectByDiscadorId(int DiscadorId)
        {
            return service.SelectByDiscadorId(DiscadorId);
        }

        SortedList<string, List<DTO.Link>> indexador = new SortedList<string, List<DTO.Link>>();
        public List<DTO.Link> SelectByIdentificador(string Indentificador)
        {
            if (!indexador.ContainsKey(Indentificador))
                indexador.Add(Indentificador, service.SelectByIdentificador(Indentificador, discadorId));

            return indexador[Indentificador];
        }
    }
}
