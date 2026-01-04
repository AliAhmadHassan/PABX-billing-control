using Tarifador.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.BLL
{
    public class Tarifa:ITarifa
    {
        public List<DTO.Tarifa> Select()
        {
            return new DAL.Tarifa().Select();
        }

        SortedList<int, DTO.Tarifa> indexador = new SortedList<int, DTO.Tarifa>();
        public DTO.Tarifa SelectById(int Id)
        {
            if (!indexador.ContainsKey(Id))
                indexador.Add(Id, new DAL.Tarifa().SelectById(Id));
            return indexador[Id];
        }

        public void Remover(DTO.Tarifa Entidade)
        {
            new DAL.Tarifa().Remover(Entidade);
        }

        public void Cadastro(DTO.Tarifa Entidade)
        {
            new DAL.Tarifa().Cadastro(Entidade);
        }

        public List<DTO.Tarifa> SelectByCadLoc(int CadLoc)
        {
            return new DAL.Tarifa().SelectByCadLoc(CadLoc);
        }

        public List<DTO.Tarifa> SelectByCarLDN(int CarLDN)
        {
            return new DAL.Tarifa().SelectByCarLDN(CarLDN);
        }

        public List<DTO.Tarifa> SelectByCadLDE(int CadLDE)
        {
            return new DAL.Tarifa().SelectByCadLDE(CadLDE);
        }

        public List<DTO.Tarifa> SelectByCadVC1(int CadVC1)
        {
            return new DAL.Tarifa().SelectByCadVC1(CadVC1);
        }

        public List<DTO.Tarifa> SelectByCadVC2(int CadVC2)
        {
            return new DAL.Tarifa().SelectByCadVC2(CadVC2);
        }

        public List<DTO.Tarifa> SelectByCadVC3(int CadVC3)
        {
            return new DAL.Tarifa().SelectByCadVC3(CadVC3);
        }
    }
}
