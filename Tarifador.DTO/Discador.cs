using System;
using System.Collections.Generic;

namespace Tarifador.DTO
{
    public class Discador:Base
    {
        public Discador()
        {
            DiscadorId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDiscador"
            , ProcedureInserir = "SPIDiscador"
            , ProcedureRemover = "SPDDiscador"
            , ProcedureListarTodos = "SPSDiscador"
            , ProcedureSelecionar = "SPSDiscadorByDiscadorId")]
		public int DiscadorId { get; set; }
		public string Descricao { get; set; }
		public string IP { get; set; }
    }
}
