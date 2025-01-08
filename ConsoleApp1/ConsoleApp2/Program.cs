
using ConsoleApp2.Models;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        //Utente utente = new Utente();   

        //utente.Nome = "Mario";
        //utente.Cognome = "Rossi";
        //utente.IdCitta = 1;
        //Console.WriteLine("Inserisci il tuo nome");

        //string nome =  Console.ReadLine();

        //Console.WriteLine("Hai scritto" + nome);
        ////ESERCIZIO 1
        //string nome;
        //List<string> list = new List<string>();

        //nome = Console.ReadLine();

        //list.Add(nome);

        //while (nome != "")
        //{
        //    nome = Console.ReadLine();
        //    if (nome != "")
        //    {
        //        list.Add(nome);
        //    }
        //}

        //Console.WriteLine("Hai scritto: " + list.Count);


        //////ESERCIZIO 2
        ////string contenutoFile = System.IO.File.ReadAllText("elenco.txt");
        //////string[]= contenutoFile.Split("\r\n");
        ////var vettoreNomi = contenutoFile.Split("\r\n");
        //////Console.WriteLine("Ci sono " + vettoreNomi.Length + " Nomi");
        //////Console.WriteLine($"Ci sono {vettoreNomi.Length} Nomi");

        ////var vettoreOrdinato = vettoreNomi.OrderBy(s => s);
        ////string contenutoDaScrivere = "";
        ////foreach (var nome in vettoreOrdinato)
        ////{
        ////    contenutoDaScrivere = contenutoDaScrivere + nome + "\r\n";
        ////}
        //// System.IO.File.WriteAllText("elencoOrdinato.txt", contenutoDaScrivere);


        ////ESERCIZIO 3
        //string contenutoFile = System.IO.File.ReadAllText("elenco2.txt");
        //var vettoreNomi = contenutoFile.Split("\r\n");
        //int totaleRossi = 0;
        //int totaleVerdi = 0;

        //foreach (var riga in vettoreNomi)
        //{
        //    var vettoreRiga = riga.Split("|");
        //    if (vettoreRiga[0] == "rossi")
        //    {
        //        totaleRossi = totaleRossi +Convert.ToInt32( vettoreRiga[1]);
        //    }
        //    else if (vettoreRiga[0] == "verdi")
        //    {
        //        totaleVerdi +=  Convert.ToInt32(vettoreRiga[1]);
        //    }
        //}
        //Console.WriteLine("Totale Rossi: " + totaleRossi);
        //Console.WriteLine("Totale Verdi: " + totaleVerdi);




        //ESERCIZIO 4
        string contenutoFile = System.IO.File.ReadAllText("elenco2.txt");
        var vettoreNomi = contenutoFile.Split("\r\n");
        List<Sacchetti> sacchettis = new List<Sacchetti>();

        foreach (var riga in vettoreNomi)
        {
            var vettoreRiga = riga.Split("|");
            var sacchetto= sacchettis.FirstOrDefault(sacchettis => sacchettis.Colore == vettoreRiga[0]);

            if(sacchetto==null)
            {
                sacchettis.Add(
                    new Sacchetti { Colore = vettoreRiga[0], Quantita = Convert.ToInt32(vettoreRiga[1]) 
                    });

            }
            else
            {
                sacchetto.Quantita += Convert.ToInt32(vettoreRiga[1]);
            }
        }

        foreach (var item in sacchettis)
        {
            Console.WriteLine($"Totale {item.Colore}: {item.Quantita}");

        }


    }
}


class Sacchetti
{
    public string Colore { get; set; }
    public int Quantita { get; set; }
}