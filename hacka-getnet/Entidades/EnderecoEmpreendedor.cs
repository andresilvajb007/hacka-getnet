using System;
using System.Collections;
using System.Collections.Generic;

namespace hacka_getnet.Entidades
{
    public class EnderecoEmpreendedor
    {
        public int Id { get; set; }

        public int EmpreendedorId { get; set; }
        public virtual Empreendedor Empreendedor { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string SiglaEstado { get; set; }

        public string Cidade { get; set; }

        public string Pais { get; set; }

        public string CEP { get; set; }

        public EnderecoEmpreendedor()
        {
        }
    }
}
