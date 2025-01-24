

using SQLEsempio.Models;
using SQLEsempio.Services;

List<Customer> listaClienti = DBServices.CaricaClientidaDB();

foreach (var item in listaClienti)
{

    Console.WriteLine(item.CompanyName);
}