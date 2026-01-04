using System;
using System.Collections.Generic;

namespace Tarifador.DTO
{
    public class Tarifa:Base
    {
        public Tarifa()
        {
            TarifaId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUTarifa"
            , ProcedureInserir = "SPITarifa"
            , ProcedureRemover = "SPDTarifa"
            , ProcedureListarTodos = "SPSTarifa"
            , ProcedureSelecionar = "SPSTarifaByTarifaId")]
		public int TarifaId { get; set; }
		public string Descricao { get; set; }
		public decimal TarLoc { get; set; }
		public int CadLoc { get; set; }
		public decimal TarLDN { get; set; }
		public int CarLDN { get; set; }
		public decimal TarLDE { get; set; }
		public int CadLDE { get; set; }
		public decimal TarVC1 { get; set; }
		public int CadVC1 { get; set; }
		public decimal TarVC2 { get; set; }
		public int CadVC2 { get; set; }
		public decimal TarVC3 { get; set; }
		public int CadVC3 { get; set; }
    }
}
