

using SQLEsempio.Models;
using SQLEsempio.Services;

//List<Customer> listaClienti = DBServices.CaricaClientidaDB();
Console.WriteLine("Inserisci la lettera iniziale della ditta da cercare");  
var lettera=Console.ReadLine();

List<Customer> listaClienti =DBServices.CaricaClientidaDBFiltrato(lettera);
foreach (var item in listaClienti)
{

    Console.WriteLine(item.CompanyName);
}