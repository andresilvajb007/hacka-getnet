using System;
namespace hacka_getnet.Entidades
{
    public class PagamentoIncentivadorPIX
    {
        public int Id { get; set; }

        public int IncentivadorId { get; set; }

        public virtual Incentivador Incentivador { get; set; }

        public decimal Valor { get; set; }

        public string ChavePixOrigem { get; set; }

        public string ChavePixDestino { get; set; }

        public string IdTransacaoPIX { get; set; }

        public DateTime DataPagamento { get; set; }
    }
}
