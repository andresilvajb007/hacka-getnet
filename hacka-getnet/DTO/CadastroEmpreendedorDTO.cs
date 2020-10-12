using System;
using System.Collections;
using System.Collections.Generic;

namespace hacka_getnet.Entidades
{
    public class CadastroEmpreendedorDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Celular { get; set; }

        public string CNPJ { get; set; }

        public string ChavePix { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public CadastroEmpreendedorDTO()
        {
        }
    }
}
