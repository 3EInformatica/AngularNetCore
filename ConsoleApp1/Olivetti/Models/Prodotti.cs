using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivetti.Models
{
    internal record Prodotti : BaseTabella
    {
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public int SalOrDisChDivID { get; set; }
        public string RifCode { get; set; }
        public string EanCode { get; set; }
        public int OrdMinimumQty { get; set; }
        public int DelMinimumQty { get; set; }
        public int DelQty { get; set; }
        public int TotDelMinimumQty { get; set; }
        public string Unit { get; set; }
        public int HierarchyID { get; set; }
        public string OldProductCode { get; set; }
        public string Type { get; set; }
        public string Plant { get; set; }
        public string Magazzino { get; set; }
    }
}
