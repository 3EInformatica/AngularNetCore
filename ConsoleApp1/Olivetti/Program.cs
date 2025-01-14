using Olivetti.DTO;
using Olivetti.Services;

//caricare lingua
var elencoLingue = LoadService.LoadLingue();

//caricare descrizione
var elencoDescrizioni = LoadService.LoadDescrizione();


//caricare prodotti
var elencoProdotti = LoadService.LoadProdotti();



//ottenere un oggetto con ProductCode Descrizione in italiano
List<DTOProdotti> listaDtoProdotti = FilterService.DescrizioneInLingua(elencoProdotti, elencoDescrizioni);


//scrivere l'oggetto creato sopra in un file JSON
var esito=SaveService.Save(listaDtoProdotti);
var esito2=SaveService.SaveGenerico<List<DTOProdotti>>(listaDtoProdotti);
if (esito)
    Console.WriteLine("Funziona!");
else
    Console.WriteLine("Non Funziona!");
