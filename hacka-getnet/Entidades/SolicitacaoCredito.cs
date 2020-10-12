using System;
using System.Collections.Generic;

namespace hacka_getnet.Entidades
{
    public enum StatusSolicitacaoCredito
    {
        EM_ANDAMENTO = 0,
        RESGATADA = 1,
        ENCERRADA = 3,
    }

    public class SolicitacaoCredito
    {
        public int Id { get; set; }

        public string NomeNegocio { get; set; }

        public int EmpreendedorId { get; set; }
        public virtual Empreendedor Empreendedor { get; set; }

        public string Motivo { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public List<ComprovanteIncentivo> ComprovanteIncentivo { get; set; }

        public string UrlImagem { get; set; }

        public int QuantidadeParcelasReembolso { get; set; }

        public List<PagamentoSolicitacaoCreditoPIX> Pagamentos { get; set; }

        public StatusSolicitacaoCredito StatusSolicitacaoCredito { get; set; }


        public SolicitacaoCredito()
        {
        }
    }
}
