using System;
using System.Collections.Generic;

namespace hacka_getnet.Entidades
{
    public class CartaoEmpreendedor
    {
        public int Id { get; set; }

        public int EmpreendedorId { get; set; }
        public virtual Empreendedor Empreendedor { get; set; }

        public string NomePortador { get; set; }

        public string NumeroCartao { get; set; }

        public string MesVencimento { get; set; }

        public string AnoVencimento { get; set; }

        public string CVV { get; set; }

        public string Bandeira { get; set; }


        public CartaoEmpreendedor()
        {
        }
    }
}
