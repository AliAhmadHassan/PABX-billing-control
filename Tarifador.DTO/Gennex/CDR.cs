using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarifador.DTO.Gennex
{
    public class CDR
    {
        public DateTime DataInicio { get; set; }
        public int Duracao { get; set; }
        public Int64 CodNoDiscador { get; set; }
        public string CallerIdDiscador { get; set; }
        public string Cliente { get; set; }
        public int DDI { get; set; }
        public int DDD { get; set; }
        public Int64 Telefone { get; set; }
        public DateTime AtendimentoPublica { get; set; }
        public DateTime FimLigacao { get; set; }
        public DateTime RingOperadora { get; set; }
        public string LigacaoStatusId { get; set; }
        public string LinkId { get; set; }
        public int CampanhaId { get; set; }
    }
}
