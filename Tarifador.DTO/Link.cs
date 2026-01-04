using System;
using System.Collections.Generic;

namespace Tarifador.DTO
{
    public class Link:Base
    {
        public Link()
        {
            LinkId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPULink"
            , ProcedureInserir = "SPILink"
            , ProcedureRemover = "SPDLink"
            , ProcedureListarTodos = "SPSLink"
            , ProcedureSelecionar = "SPSLinkByLinkId")]
		public int LinkId { get; set; }
		public int DiscadorId { get; set; }
		public int OperadoraId { get; set; }
		public string Indentificador { get; set; }
		public string IndentificadorFisico { get; set; }
    }
}
