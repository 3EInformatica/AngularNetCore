using Json.Moldels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Common
{
    internal class SearchService
    {
        public static List<Corsi> FitroInCorsoDiSvolgimento(List<Corsi> listaCorsi)
        {
            return listaCorsi.Where(s=>s.DataInizio < DateTime.Now &&  DateTime.Now < s.DataFine).ToList();
            
        }
    }
}
