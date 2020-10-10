﻿using System;
namespace hacka_getnet.Entidades
{
    public class SolicitacaoCreditoDTO
    {
        public int Id { get; set; }

        public int EmpreendedorId { get; set; }
        public virtual EmpreendedorDTO EmpreendedorDTO { get; set; }

        public string Motivo { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataSolicitacao { get; set; }

        public SolicitacaoCreditoDTO()
        {
        }
    }
}