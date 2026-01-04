using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarifador.BLL
{
    public class Calculo
    {
        Cadencia cadenciaService = new Cadencia();

        public decimal calcular(DTO.Bilhete bilhete, DTO.Tarifa tarifa)
        {
            int duracao = bilhete.Duracao;
            decimal valorFinal = 0;

            DTO.Cadencia cadencia = null;
            decimal valorTarifa = 0;
            if (bilhete.Telefone.ToString().Length > 8)
            {

                if (bilhete.DDD == 11)
                {
                    cadencia = cadenciaService.SelectById(tarifa.CadVC1);
                    valorTarifa = tarifa.TarVC1;
                }
                else
                {
                    cadencia = cadenciaService.SelectById(tarifa.CadVC2);
                    valorTarifa = tarifa.TarVC2;
                }
            }
            else
            {
                if (bilhete.DDD == 11)
                {
                    cadencia = cadenciaService.SelectById(tarifa.CadLoc);
                    valorTarifa = tarifa.TarLoc;
                }
                else
                {
                    cadencia = cadenciaService.SelectById(tarifa.CadLDE);
                    valorTarifa = tarifa.TarLDE;
                }

            }

            if (duracao < cadencia.Cadencia1)
                return 0;
            else
            {
                valorFinal += valorTarifa * (Convert.ToDecimal(cadencia.Cadencia2) / 60);
                //valorFinal += valorTarifa * (Convert.ToDecimal(cadencia.Cadencia1) / 60);
                int duracaoRestante = duracao - cadencia.Cadencia2;
                if (duracaoRestante > cadencia.Cadencia2)
                {
                    duracaoRestante = duracao - cadencia.Cadencia2;
                    decimal fator = (decimal)duracaoRestante / cadencia.Cadencia3;

                    if (fator - (int)fator > 0)
                        fator = (int)fator + 1;
                    else
                        fator = (int)fator;

                    valorFinal += valorTarifa * fator * (Convert.ToDecimal(cadencia.Cadencia3) / 60);
                }
            }
            return valorFinal;
        }
    }
}
