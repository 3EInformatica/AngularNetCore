using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEsempio.Models
{
    internal record Utente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataUltimoAccesso { get; set; }
        public Guid id { get; set; }
    }
}
