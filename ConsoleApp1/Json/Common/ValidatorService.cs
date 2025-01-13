
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Json.Common
{
    internal class ValidatorService
    {
        internal static string PulisciStringa(string contenutoFileJson)
        {
            List<string> elencoPulito= new List<string>();

            var elenco = JsonSerializer.Deserialize<JsonArray>(contenutoFileJson);
            for (int i = 0; i < elenco.Count; i++)
            {
                var dataInizio = elenco[i]["DataInizio"];
                var dataFine = elenco[i]["DataFine"];
                var sequenza = elenco[i]["Sequenza"];
                var moduliOre = elenco[i]["ModuliOre"];
                var crediti = elenco[i]["Crediti"];
                var guid = elenco[i]["Guid"];

                var valido = true;
                if (!DateTime.TryParse(dataInizio.ToString(), out DateTime x))
                    valido = false;
                if (!DateTime.TryParse(dataFine.ToString(), out DateTime x1))
                    valido = false;
                if (!int.TryParse(sequenza.ToString(), out int x2))
                    valido = false;
                if (!int.TryParse(moduliOre.ToString(), out int x3))
                    valido = false;
                if (!int.TryParse(crediti.ToString(), out int x4))
                    valido = false;
                if (!Guid.TryParse(guid.ToString(), out Guid x5))
                    valido = false;

                if (valido)
                {
                    elenco[i]["DataInizio"] = elenco[i]["DataInizio"].ToString().Substring(0, 10);
                    elenco[i]["DataFine"] = elenco[i]["DataFine"].ToString().Substring(0, 10);

                    elencoPulito.Add(elenco[i].ToString());
                }
            }

            var stringapulita="[" +String.Join(", ", elencoPulito.ToArray())+"]";

            return stringapulita;
        }
    }
}