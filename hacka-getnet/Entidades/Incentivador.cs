using System;
using System.Collections.Generic;

namespace hacka_getnet.Entidades
{
    public class Incentivador
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string ChavePix { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string Role { get; set; }

        public List<ComprovanteIncentivo> ComprovanteIncentivo { get; set; }

        public Incentivador()
        {
        }
    }
}
