

using SQLEsempio.Models;
using SQLEsempio.Services;

//List<Customer> listaClienti = DBServices.CaricaClientidaDB();
//Console.WriteLine("Inserisci la lettera iniziale della ditta da cercare");  
//var lettera=Console.ReadLine();

//List<Customer> listaClienti =DBServices.CaricaClientidaDBFiltrato(lettera);
//foreach (var item in listaClienti)
//{

//    Console.WriteLine(item.CompanyName);
//}

//Console.WriteLine("Inserisci la compagnia");
//var compagnia = Console.ReadLine();
//Console.WriteLine("Inserisci il numero di telefono");
//var telefono = Console.ReadLine();
//var risultato=DBServices.InserisiCorriere(compagnia, telefono);
//if (risultato)
//{
//    Console.WriteLine("Inserimento avvenuto con successo");
//}
//else
//{
//    Console.WriteLine("Inserimento fallito");
//}

Console.WriteLine("Inserisci la username");
var userName = Console.ReadLine();
Console.WriteLine("Inserisci la password");
var password = Console.ReadLine();
var risultato = DBServices.Login(userName, password);
if (risultato!=null)
{
    Console.WriteLine($"Benvenuto {risultato.Cognome} {risultato.Nome}");
}
else
{
    Console.WriteLine("User o password errate");
}
