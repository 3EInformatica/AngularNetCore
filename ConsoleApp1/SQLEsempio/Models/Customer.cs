﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEsempio.Models
{
    internal record Customer
    {
       public string CustomerID { get; set; }
       public string CompanyName { get; set; }
       public string ContactName { get; set; }

    }
}
