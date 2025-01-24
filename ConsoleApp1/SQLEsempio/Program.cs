

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

Console.WriteLine("Inserisci la compagnia");
var compagnia = Console.ReadLine();
Console.WriteLine("Inserisci il numero di telefono");
var telefono = Console.ReadLine();
var risultato=DBServices.InserisiCorriere(compagnia, telefono);
if (risultato)
{
    Console.WriteLine("Inserimento avvenuto con successo");
}
else
{
    Console.WriteLine("Inserimento fallito");
}
