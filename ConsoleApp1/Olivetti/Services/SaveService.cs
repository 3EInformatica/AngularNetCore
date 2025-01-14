using Olivetti.DTO;
using Olivetti.Models;
using Olivetti.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Olivetti.Services
{
    internal class SaveService
    {

        public static bool SaveGenerico<T>(T lista)
        {
            try
            {
                var stringaDaSalvare = JsonSerializer.Serialize(lista);
                File.WriteAllText(Costanti.pathSaveExport, stringaDaSalvare);
                return true;
            }
            catch (Exception ecc)
            {
                File.AppendAllText("c:\\erroriLog.txt", ecc.Message);
                return false;
            }


        }


        public static bool Save(List<DTOProdotti> lista)
        {
            try
            {
                var stringaDaSalvare = JsonSerializer.Serialize(lista);
                File.WriteAllText(Costanti.pathSaveExport, stringaDaSalvare);
                return true;
            }
            catch (Exception ecc)
            {
                File.AppendAllText("c:\\erroriLog.txt", ecc.Message);
                return false;   
            }

          
        }
        public static bool Save(List<Prodotti> lista)
        {
            try
            {
                var stringaDaSalvare = JsonSerializer.Serialize(lista);
                File.WriteAllText(Costanti.pathSaveExport, stringaDaSalvare);
                return true;
            }
            catch (Exception ecc)
            {
                File.AppendAllText("c:\\erroriLog.txt", ecc.Message);
                return false;
            }


        }
        public static bool Save(List<Descrizione> lista)
        {
            try
            {
                var stringaDaSalvare = JsonSerializer.Serialize(lista);
                File.WriteAllText(Costanti.pathSaveExport, stringaDaSalvare);
                return true;
            }
            catch (Exception ecc)
            {
                File.AppendAllText("c:\\erroriLog.txt", ecc.Message);
                return false;
            }


        }
    }
}
