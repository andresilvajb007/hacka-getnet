using System;
using System.Collections.Generic;

namespace hacka_getnet.Entidades
{
    public class ConfiguracaoApp
    {
        public int Id { get; set; }

        public string ChavePixApp { get; set; }

        public string GetNetId { get; set; }

        public double TaxaJurosACobrarDoEmpreendedor { get; set; }

        public double TaxaJurosAPagarAoIncentivador { get; set; }

        public DateTime DataConfiguracao { get; set; }


        public ConfiguracaoApp()
        {
        }
    }
}
