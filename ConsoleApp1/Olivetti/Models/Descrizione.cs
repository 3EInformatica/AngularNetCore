using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivetti.Models
{
    internal record Descrizione : BaseTabella
    {

        public int ProductID { get; set; }
        public int LanguageID { get; set; }
        public string Description { get; set; }


    }
}
