using System;
using System.Collections.Generic;

namespace Tarifador.DTO
{
    public class Carteira:Base
    {
        public Carteira()
        {
            CarteiraId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUCarteira"
            , ProcedureInserir = "SPICarteira"
            , ProcedureRemover = "SPDCarteira"
            , ProcedureListarTodos = "SPSCarteira"
            , ProcedureSelecionar = "SPSCarteiraByCarteiraId")]
		public int CarteiraId { get; set; }
		public string Descricao { get; set; }
    }
}
