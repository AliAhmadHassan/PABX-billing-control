using System;
using System.Collections.Generic;

namespace Tarifador.DTO
{
    public class Cadencia:Base
    {
        public Cadencia()
        {
            CadenciaId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUCadencia"
            , ProcedureInserir = "SPICadencia"
            , ProcedureRemover = "SPDCadencia"
            , ProcedureListarTodos = "SPSCadencia"
            , ProcedureSelecionar = "SPSCadenciaByCadenciaId")]
		public int CadenciaId { get; set; }
		public string Descricao { get; set; }
		public int Cadencia1 { get; set; }
		public int Cadencia2 { get; set; }
		public int Cadencia3 { get; set; }
    }
}
