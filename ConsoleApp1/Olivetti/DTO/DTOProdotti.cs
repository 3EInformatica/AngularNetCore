using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivetti.DTO
{
    internal record DTOProdotti
    {
        public string CodiceProdotto { get; set; }
        public string Descrizione { get; set; }
    }
}
