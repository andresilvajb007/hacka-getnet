using System;
namespace hacka_getnet.Entidades
{
    public class PagamentoEmpreendedorPIX
    {
        public int Id { get; set; }

        public int EmpreendedorId { get; set; }

        public virtual Empreendedor Empreendedor { get; set; }

        public decimal Valor { get; set; }

        public string ChavePixOrigem { get; set; }

        public string ChavePixDestino { get; set; }

        public string IdTransacaoPIX { get; set; }

        public DateTime DataPagamento { get; set; }
    }
}
