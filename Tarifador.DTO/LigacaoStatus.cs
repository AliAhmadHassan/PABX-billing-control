using System;
using System.Collections.Generic;

namespace Tarifador.DTO
{
    public class LigacaoStatus:Base
    {
        public LigacaoStatus()
        {
            LigacaoStatusId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPULigacaoStatus"
            , ProcedureInserir = "SPILigacaoStatus"
            , ProcedureRemover = "SPDLigacaoStatus"
            , ProcedureListarTodos = "SPSLigacaoStatus"
            , ProcedureSelecionar = "SPSLigacaoStatusByLigacaoStatusId")]
		public int LigacaoStatusId { get; set; }
		public string Descricao { get; set; }
		public bool Tarifa { get; set; }
    }
}
