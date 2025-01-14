using Olivetti.DTO;
using Olivetti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Olivetti.Services
{
    internal class FilterService
    {
        public static List<DTOProdotti> DescrizioneInLingua(
            List<Prodotti> listaProdotti,
            List<Descrizione> listaDescrizioni
            ) {

            List<DTOProdotti> risultato = new List<DTOProdotti>();

            foreach (var prodotto in listaProdotti)
            {
                DTOProdotti dto = new DTOProdotti();    
                dto.CodiceProdotto = prodotto.ProductCode;
                dto.Descrizione= listaDescrizioni.Where(x => x.ProductID == prodotto.Id && x.LanguageID==5).FirstOrDefault().Description;

                risultato.Add(dto); 
            }


            var risultato2 =(from prod in listaProdotti
                            from desc in listaDescrizioni
                            where prod.Id == desc.ProductID && desc.LanguageID == 5 
                            select new DTOProdotti
                            {
                                CodiceProdotto = prod.ProductCode,
                                Descrizione = desc.Description
                            }).ToList();


            return risultato;
        }
    }
}
