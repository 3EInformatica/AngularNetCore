using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    public class Utente
    {
        public int Id { get; set; }

        public string Nome { get; set; } = "";
        public string Cognome { get; set; }
        public DateOnly DataNascita { get; set; }
        public string? CodiceFiscale { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Indirizzo { get; set; }
        //public string Citta { get; set; }
        //public string Provincia { get; set; }
        //public string CAP { get; set; }
        public int IdCitta { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Calcola l'età dell'utente
        /// </summary>
        /// <returns>restituisco un intero</returns>
        public int Eta()
        {
            return DateTime.Now.Year - DataNascita.Year;
        }
    }

}
