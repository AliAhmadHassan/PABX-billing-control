using System;
using System.Collections.Generic;

namespace Tarifador.DTO
{
    public class Bilhete:Base
    {
        public Bilhete()
        {
            CDRId = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUBilhete"
            , ProcedureInserir = "SPIBilhete"
            , ProcedureRemover = "SPDBilhete"
            , ProcedureListarTodos = "SPSBilhete"
            , ProcedureSelecionar = "SPSBilheteByCDRId")]
		public Int64 CDRId { get; set; }
		public int DiscadorId { get; set; }
		public int TarifaId { get; set; }
		public DateTime Data { get; set; }
		public DateTime DataInicio { get; set; }
		public int Duracao { get; set; }
		public decimal Valor { get; set; }
		public Int64 CodNoDiscador { get; set; }
		public string CallerIdDiscador { get; set; }
		public string Cliente { get; set; }
		public int DDI { get; set; }
		public int DDD { get; set; }
		public Int64 Telefone { get; set; }
		public DateTime AtendimentoPublica { get; set; }
		public DateTime FimLigacao { get; set; }
		public DateTime RingOperadora { get; set; }
		public int LigacaoStatusId { get; set; }
		public int LinkId { get; set; }
		public int OperadoraId { get; set; }
		public int CampanhaId { get; set; }
    }
}
