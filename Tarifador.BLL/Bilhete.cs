using Tarifador.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifador.BLL
{
    public class Bilhete:IBilhete
    {
        public List<DTO.Bilhete> Select()
        {
            return new DAL.Bilhete().Select();
        }

        public DTO.Bilhete SelectById(int Id)
        {
            return new DAL.Bilhete().SelectById(Id);
        }

        public void Remover(DTO.Bilhete Entidade)
        {
            new DAL.Bilhete().Remover(Entidade);
        }

        public void Cadastro(DTO.Bilhete Entidade)
        {
            new DAL.Bilhete().Cadastro(Entidade);
        }

        public List<DTO.Bilhete> SelectByDiscadorId(int DiscadorId)
        {
            return new DAL.Bilhete().SelectByDiscadorId(DiscadorId);
        }

        public List<DTO.Bilhete> SelectByTarifaId(int TarifaId)
        {
            return new DAL.Bilhete().SelectByTarifaId(TarifaId);
        }

        public List<DTO.Bilhete> SelectByLigacaoStatusId(int LigacaoStatusId)
        {
            return new DAL.Bilhete().SelectByLigacaoStatusId(LigacaoStatusId);
        }

        public List<DTO.Bilhete> SelectByLinkId(int LinkId)
        {
            return new DAL.Bilhete().SelectByLinkId(LinkId);
        }

        public List<DTO.Bilhete> SelectByOperadoraId(int OperadoraId)
        {
            return new DAL.Bilhete().SelectByOperadoraId(OperadoraId);
        }

        public List<DTO.Bilhete> SelectByCampanhaId(int CampanhaId)
        {
            return new DAL.Bilhete().SelectByCampanhaId(CampanhaId);
        }
    }
}
