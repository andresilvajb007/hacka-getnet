using System;
namespace hacka_getnet.Entidades
{
    public class ComprovanteIncentivo
    {
        public int Id { get; set; }

        public string UrlImagem { get; set; }

        public int IncentivadorId { get; set; }
        public virtual Incentivador Incentivador { get; set; }

        public int SolicitacaoCreditoId { get; set; }
        public virtual SolicitacaoCredito SolicitacaoCredito { get; set; }

        public decimal Valor { get; set; }


        public DateTime DataUpload { get; set; }

        public ComprovanteIncentivo()
        {
        }
    }
}
