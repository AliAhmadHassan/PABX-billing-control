using System;
using System.Collections.Generic;

namespace Tarifador.DTO
{
    public class Campanha:Base
    {
        public Campanha()
        {
            CampanhaId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUCampanha"
            , ProcedureInserir = "SPICampanha"
            , ProcedureRemover = "SPDCampanha"
            , ProcedureListarTodos = "SPSCampanha"
            , ProcedureSelecionar = "SPSCampanhaByCampanhaId")]
		public int CampanhaId { get; set; }
		public int DiscadorId { get; set; }
		public int CampanhaIdNoDiscador { get; set; }
		public string Descricao { get; set; }
		public int CarteiraId { get; set; }
    }
}
