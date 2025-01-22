using Olivetti.Models;
using Olivetti.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Olivetti.Services
{
    internal class CsvSerivce
    {
        public static List<T> Load<T>(string path,
            string separatoreRiga,
            string separatoreValore,
            string elencoCampi,
            bool primaRigaIsHeader = true)
        {
            List<T> lista = new List<T>();

            string contenutoFile = File.ReadAllText(path);
            var vettore = contenutoFile.Split(separatoreRiga);

            var elencoDeiNomiDelleProprieta = elencoCampi.Split(";");

            int inizio = 0;
            if (primaRigaIsHeader)
                inizio = 1;

            foreach (var riga in vettore.Skip(inizio))
            {
                if (riga == "")
                    continue;
                var elementoDellaRigaDati = riga.Split(separatoreValore);

                var oggetto = GetInstance(typeof(T).FullName);
                for (int i = 0; i < elencoDeiNomiDelleProprieta.Length; i++)
                {
                    var property = typeof(T).GetProperty(elencoDeiNomiDelleProprieta[i]);

                    if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(oggetto, Convert.ToInt32(elementoDellaRigaDati[i]));
                    }
                    else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                    {
                        property.SetValue(oggetto, (elementoDellaRigaDati[i] == "NULL") ? null : Convert.ToDateTime(elementoDellaRigaDati[i]));
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        property.SetValue(oggetto, (elementoDellaRigaDati[i] == "1") ? true : false);
                    }
                    else
                    {
                        property.SetValue(oggetto, elementoDellaRigaDati[i]);
                    }
                }
                lista.Add((T)oggetto);
            }


            return lista;
        }
        public static object GetInstance(string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }

        public static bool Save<T>(List<T> lista, string path, string elencoCampi)
        {
            string contenutoDaSalvare = "";

            contenutoDaSalvare += elencoCampi;
            var elencoProprieta = elencoCampi.Split(";");

          
            foreach (var item in lista)
            {
                for (int i=0;i< elencoProprieta.Length;i++)
                {
                    var property = typeof(T).GetProperty(elencoProprieta[i]);
                    if (property.GetValue(item) != null)
                    {
                        contenutoDaSalvare += property.GetValue(item).ToString();
                    }
                    contenutoDaSalvare += ";";
                }
                contenutoDaSalvare = contenutoDaSalvare +"\r\n";
            }
            File.WriteAllText(path, contenutoDaSalvare);
            return true;
        }

    }
}
