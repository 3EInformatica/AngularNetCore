using Json.Common;
using Json.Moldels;

//Differenza tra record e class
//Corsi c = new Corsi();
//c.Testo = "Ciao";

//Corsi d = new Corsi();
//d.Testo = "Ciao";

//if (c == d)
//{
//    Console.WriteLine("Uguali");  //record
//}
//else
//{
//    Console.WriteLine("Diversi");  //class
//}   



//letturafile e carcamento in una lista di corsi
 var listaCorsiNelFile=  IoSystem.Read();

//filtra i corsi in corso di svolgimento
var listCorsiFiltrati = SearchService.FitroInCorsoDiSvolgimento(listaCorsiNelFile);

//scrivere su file il risultato
var esito= IoSystem.Write(listCorsiFiltrati);  
if(esito)
{
    Console.WriteLine("Operazione completata con successo");
}
else
{
    Console.WriteLine("Operazione fallita");
}