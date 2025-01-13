using Json.Moldels;
using Json.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Json.Common
{
    internal class IoSystem
    {
        public static List<Corsi> Read()
        {
            string contenutoFileJson = File.ReadAllText(Contanti.pathFileToRead);

            //VALIDAZIONE E PULIZA DELLA STRINGA CON IL CONTENUTO DEL FILE
            string contenutoPulito= ValidatorService.PulisciStringa(contenutoFileJson);


            //List<CorsiStage> listaCorsi = JsonSerializer.Deserialize<List<CorsiStage>>(contenutoFileJson);
            List<Corsi> listaCorsi = JsonConvert.DeserializeObject<List<Corsi>>(contenutoPulito);
          


            return listaCorsi;
        }

        public static bool Write(List<Corsi> listaCorsiFiltrati)
        {
            //scrivere su file il risultato
            try
            {
                var contenutJson = JsonConvert.SerializeObject(listaCorsiFiltrati);
                File.WriteAllText(Contanti.pathFileToWrite, contenutJson);
                return true;
            }
            catch (Exception ex)
            {
               File.WriteAllText(Contanti.pathFileToError, ex.Message);

                return false;   
            }


           

           
        }
    }
}
