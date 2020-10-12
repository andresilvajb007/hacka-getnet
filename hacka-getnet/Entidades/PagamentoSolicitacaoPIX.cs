using System;
namespace hacka_getnet.Entidades
{
    public enum StatusPagamento
    {
        PENDENTE_RESGATAR = 0,
        RESGATADO = 1,
    }

    public class PagamentoSolicitacaoCreditoPIX
    {
        public int Id { get; set; }

        public int SolicitacaoCreditoId { get; set; }

        public virtual SolicitacaoCredito SolicitacaoCredito {get;set;}

        public decimal Valor { get; set; }

        public string ChavePixOrigem { get; set; }

        public string ChavePixDestino { get; set; }

        public string IdTransacaoPIX { get; set; }

        public StatusPagamento StatusPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
