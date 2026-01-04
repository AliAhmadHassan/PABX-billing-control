using System;
using System.Collections.Generic;

namespace Tarifador.DTO
{
    public class Operadora:Base
    {
        public Operadora()
        {
            OperadoraId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUOperadora"
            , ProcedureInserir = "SPIOperadora"
            , ProcedureRemover = "SPDOperadora"
            , ProcedureListarTodos = "SPSOperadora"
            , ProcedureSelecionar = "SPSOperadoraByOperadoraId")]
		public int OperadoraId { get; set; }
		public string Descricao { get; set; }
		public string Contrato { get; set; }
		public int TarifaId { get; set; }
    }
}
