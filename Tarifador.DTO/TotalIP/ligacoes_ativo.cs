using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifador.DTO.TotalIP
{
    public class ligacoes_ativo
    {
        public int id { get; set; }
        public string destino { get; set; }
        public int duracao { get; set; }
        public int billing { get; set; }
        public string status { get; set; }
        public string ramal { get; set; }
        public DateTime data { get; set; }
        public string tipo_ligacao { get; set; }
        public decimal custo { get; set; }
        public decimal custo_total { get; set; }
        public decimal custo_arredondado { get; set; }
        public int billing_arredondado { get; set; }
        public string filial { get; set; }
        public string uniqueid { get; set; }
        public int id_campanha { get; set; }
        public int id_rota { get; set; }
        public string nome_rota { get; set; }
    }
}
