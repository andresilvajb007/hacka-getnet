﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace hacka_getnet.Entidades
{
    public class Empreendedor
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string ChavePix { get; set; }

        public List<SolicitacaoCredito> SolicitacoesCredito { get; set; }

        public Empreendedor()
        {
        }
    }
}
