using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Common
{
    internal class Validator
    {

        public static bool ValidateGuid(string value)
        {
            var esito = Guid.TryParse(value, out Guid guid);
            if (esito == false)
            {
                Console.WriteLine($"Errore in {value}");
            }

            return esito;
        }
        public static bool ValidateInt(string value)
        {
            var esito = Int32.TryParse(value, out Int32 guid);
            if (esito == false)
            {
                Console.WriteLine($"Errore in {value}");
            }

            return esito;
        }

        public static bool ValidateBool(string value)
        {
            //var esito = bool.TryParse(value, out bool guid);
            //if (esito == false)
            //{
            //    Console.WriteLine($"Errore in {value}");
            //}

            bool esito = true;
            if(value== "0" || value == "1")
            {
                esito = true;
            }
            else
            {
                esito = false;
                Console.WriteLine($"Errore in {value}");
            }

            return esito;
        }
        public static bool ValidateDateTime(string value)
        {
            var esito = DateTime.TryParse(value, out DateTime guid);
            if (esito == false)
            {
                Console.WriteLine($"Errore in {value}");
            }

            return esito;
        }

        public static bool ValidatorEmail(string value)
        {
            if(value=="")
                return true;

            var esito = false;
            if (value.Contains("@") 
                && value.Contains(".") 
                && !value.Contains(" ")
                && !value.Contains("..")
                && !value.Contains("+")
                && !value.Contains("!")
                && value.IndexOf("@")< value.LastIndexOf(".") //mario@google.com
                )
            {
                esito = true;
            }
            else
            {
                Console.WriteLine($"Errore in {value}");
            }
            return esito;
        }
    }
}
