using System;
namespace hacka_getnet.Entidades
{
    public enum StatusCobrancaRecorrente
    {
        PENDENTE_PAGAMENTO = 0,
        PAGA = 1
    }

    public class CobrancaRecorrente
    {
        public int Id { get; set; }

        public int EmpreendedorId { get; set; }
        public virtual Empreendedor Empreendedor { get; set; }

        public int SolicitacaoCreditoId { get; set; }
        public virtual SolicitacaoCredito SolicitacaoCredito { get; set; }

        public decimal Valor { get; set; }

        public StatusCobrancaRecorrente StatusCobrancaRecorrente { get; set; }

        public DateTime DataCobranca { get; set; }
    }
}
