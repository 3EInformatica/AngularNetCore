using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Moldels
{
    internal class Corsi
    {
        public Guid Guid { get; set; }
        public int Sequenza { get; set; }
        public string Codice { get; set; }
        public string Titolo { get; set; }
        public string EmailContatto { get; set; }
        public string Autore { get; set; }
        public string Abstract { get; set; }
        public string Programma { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public string Icona { get; set; }
        public string NomeFileImmagine { get; set; }
        public string NomeFileIcona { get; set; }
        public int ModuliOre { get; set; }
        public int Crediti { get; set; }
        public string RichiediAccettazione { get; set; }
        public string InviaNotificaEmail { get; set; }
        public string Testo { get; set; }
    }
    internal class CorsiStage
    {
        public string Guid { get; set; }
        public string Sequenza { get; set; }
        public string Codice { get; set; }
        public string Titolo { get; set; }
        public string EmailContatto { get; set; }
        public string Autore { get; set; }
        public string Abstract { get; set; }
        public string Programma { get; set; }
        public string DataInizio { get; set; }
        public string DataFine { get; set; }
        public string Icona { get; set; }
        public string NomeFileImmagine { get; set; }
        public string NomeFileIcona { get; set; }
        public string ModuliOre { get; set; }
        public string Crediti { get; set; }
        public string RichiediAccettazione { get; set; }
        public string InviaNotificaEmail { get; set; }
        public string Testo { get; set; }
    }

}
