using System;
using System.Collections.Generic;

namespace hacka_getnet.Entidades
{
    public class SolicitacaoCredito
    {
        public int Id { get; set; }

        public int EmpreendedorId { get; set; }
        public virtual Empreendedor Empreendedor { get; set; }

        public string Motivo { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public List<ComprovanteIncentivo> ComprovanteIncentivo { get; set; }

        public string UrlImagem { get; set; }

        public int QuantidadeParcelasReembolso { get; set; }


        public SolicitacaoCredito()
        {
        }
    }
}
