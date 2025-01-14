using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivetti.Models
{
    internal record Lingua:BaseTabella 
    {
        public string LanguageID { get; set; }
        public string SAPLanguageID { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        
    }
}
