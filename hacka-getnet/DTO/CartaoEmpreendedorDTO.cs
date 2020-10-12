using System;
namespace hacka_getnet.DTO
{
    public class CartaoEmpreendedorDTO
    {
        public int Id { get; set; }

        public int EmpreendedorId { get; set; }       

        public string NomePortador { get; set; }

        public string NumeroCartao { get; set; }

        public string MesVencimento { get; set; }

        public string AnoVencimento { get; set; }

        public string CVV { get; set; }

        public string Bandeira { get; set; }

        public CartaoEmpreendedorDTO()
        {
        }
    }
}
