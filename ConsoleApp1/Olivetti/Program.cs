using Olivetti.DTO;
using Olivetti.Models;
using Olivetti.Services;
using Olivetti.Settings;

//caricare lingua
var elencoLingue = //LoadService.LoadLingue();
    CsvSerivce.Load<Lingua>(Costanti.pathLingua,
    "\r\n",
    ";",
    "Id;LanguageID;SAPLanguageID;Description;Status;IsDeleted;CreatedOn;CreatedUser;ModifiedOn;ModifiedUser");

//caricare descrizione
var elencoDescrizioni = //LoadService.LoadDescrizione();
    CsvSerivce.Load<Descrizione>(Costanti.pathDescrizione,
    "\r\n",
    ";",
    "Id;ProductID;LanguageID;Description;IsDeleted;CreatedOn;CreatedUser;ModifiedOn;ModifiedUser");


//caricare prodotti
var elencoProdotti =// LoadService.LoadProdotti();
    CsvSerivce.Load<Prodotti>(Costanti.pathProdotti,
    "\r\n",
    ";",
    "Id;ProductCode;Description;SalOrDisChDivID;RifCode;EanCode;OrdMinimumQty;DelMinimumQty;DelQty;TotDelMinimumQty;UnitHierarchyID;OldProductCode;Type;Plant;Magazzino;IsDeleted;CreatedOn;CreatedUser;ModifiedOn;ModifiedUser");



//ottenere un oggetto con ProductCode Descrizione in italiano
List<DTOProdotti> listaDtoProdotti = FilterService.DescrizioneInLingua(elencoProdotti, elencoDescrizioni);


//scrivere l'oggetto creato sopra in un file JSON
var esito = SaveService.Save(listaDtoProdotti);
var esito2 = SaveService.SaveGenerico<List<DTOProdotti>>(listaDtoProdotti);
if (esito)
    Console.WriteLine("Funziona!");
else
    Console.WriteLine("Non Funziona!");

