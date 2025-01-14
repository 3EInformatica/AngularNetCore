using Olivetti.Models;
using Olivetti.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olivetti.Services
{
    internal class LoadService
    {
        public static List<Prodotti> LoadProdotti()
        {
            List<Prodotti> listaProdotti = new List<Prodotti>();

            string contenutoFile = System.IO.File.ReadAllText(Costanti.pathProdotti);
            var vettore = contenutoFile.Split("\r\n");

            foreach (var riga in vettore.Skip(1))
            {
                if (riga == "")
                    continue;
                var elemento = riga.Split(";");
                Prodotti p= new Prodotti();
                p.Id = Convert.ToInt32(elemento[0]);
                p.ProductCode = elemento[1];
                p.Description = elemento[2];
                p.SalOrDisChDivID = Convert.ToInt32(elemento[3]);
                p.RifCode = elemento[4];
                p.EanCode = elemento[5];
                p.OrdMinimumQty = Convert.ToInt32(elemento[6]);
                p.DelMinimumQty = Convert.ToInt32(elemento[7]);
                p.DelQty = Convert.ToInt32(elemento[8]);
                p.TotDelMinimumQty = Convert.ToInt32(elemento[9]);
                p.Unit = elemento[10];
                p.HierarchyID = Convert.ToInt32(elemento[11]);
                p.OldProductCode  = elemento[12];
                p.Type = elemento[13];
                p.Plant = elemento[14];
                p.Magazzino = elemento[15];
                p.IsDeleted = (elemento[16] == "1") ? true:false ;
                p.CreatedOn = Convert.ToDateTime(elemento[17]);
                p.CreatedUser = elemento[18];
                p.ModifiedOn =(elemento[19]=="NULL")?null: Convert.ToDateTime(elemento[19]);
                p.ModifiedUser = elemento[20];
                listaProdotti.Add(p);    
            }

            return listaProdotti;
        }

        public static List<Lingua> LoadLingue()
        {
            List<Lingua> listaLingua = new List<Lingua>();

            string contenutoFile = System.IO.File.ReadAllText(Costanti.pathLingua);
            var vettore = contenutoFile.Split("\r\n");

            foreach (var riga in vettore.Skip(1))
            {
                if (riga == "")
                    continue;
                var elemento = riga.Split(";");
                Lingua p = new Lingua();
                p.Id = Convert.ToInt32(elemento[0]);
                p.LanguageID = elemento[1];
                p.SAPLanguageID = elemento[2];
                p.Description = elemento[3];
                p.Status = (elemento[4]=="1")?true:false;
                p.IsDeleted = (elemento[5] == "1") ? true : false;
                p.CreatedOn = Convert.ToDateTime(elemento[6]);
                p.CreatedUser = elemento[7];
                p.ModifiedOn = (elemento[8] == "NULL") ? null : Convert.ToDateTime(elemento[8]);
                p.ModifiedUser = elemento[9];
                listaLingua.Add(p);
            }

            return listaLingua;
        }
        public static List<Descrizione> LoadDescrizione()
        {
            List<Descrizione> listaDescrizione = new List<Descrizione>();

            string contenutoFile = System.IO.File.ReadAllText(Costanti.pathDescrizione);
            var vettore = contenutoFile.Split("\r\n");

            foreach (var riga in vettore.Skip(1))
            {
                if (riga == "")
                    continue;
                var elemento = riga.Split(";");
                Descrizione p = new Descrizione();
                p.Id = Convert.ToInt32(elemento[0]);
                p.ProductID =Convert.ToInt32( elemento[1]);
                p.LanguageID =Convert.ToInt32( elemento[2]);
                p.Description = elemento[3];
                p.IsDeleted = (elemento[4] == "1") ? true : false;
                p.CreatedOn = Convert.ToDateTime(elemento[5]);
                p.CreatedUser = elemento[6];
                p.ModifiedOn = (elemento[7] == "NULL") ? null : Convert.ToDateTime(elemento[7]);
                p.ModifiedUser = elemento[8];
                listaDescrizione.Add(p);
            }

            return listaDescrizione;
        }

    }
}
