using System;
using System.Collections.Generic;

namespace hacka_getnet.Entidades
{
    public class Incentivador
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string ChavePix { get; set; }

        public List<ComprovanteIncentivo> ComprovanteIncentivo { get; set; }

        public Incentivador()
        {
        }
    }
}
