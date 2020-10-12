using System;
using System.Collections;
using System.Collections.Generic;

namespace hacka_getnet.Entidades
{
    public class Empreendedor
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Celular { get; set; }

        public string CNPJ { get; set; }

        public string ChavePix { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string Role { get; set; }

        public List<SolicitacaoCredito> SolicitacoesCredito { get; set; }

        public List<PagamentoEmpreendedorPIX> PagamentosRecebidos { get; set; }

        public List<CobrancaRecorrente> Cobrancas { get; set; }

        public virtual EnderecoEmpreendedor Endereco { get; set; }

        public virtual CartaoEmpreendedor Cartao { get; set; }

        public Empreendedor()
        {
        }
    }
}
