
using ConsoleApp3.Models;

List<Comune> comune = new List<Comune>();

string contenutoFile = System.IO.File.ReadAllText("C:\\Users\\ACER\\source\\repos\\3EInformatica\\AngularNetCore\\ConsoleApp1\\comuni.csv");
var vettoreComuni = contenutoFile.Split("\r\n");
//int i = 0;
foreach (var rigaComune in vettoreComuni.Skip(1))
{
    //i++;
    //if (i == 1)
    //{
    //    continue; //break;
    //}
    var elementoRigaComune = rigaComune.Split(";");

    var objComune = new Comune();
    objComune.Cap = elementoRigaComune[0];
    objComune.NomeComune = elementoRigaComune[1];
    objComune.Provincia = elementoRigaComune[2];
    objComune.Regione = elementoRigaComune[3];
    objComune.CodiceRegione = elementoRigaComune[4];
    objComune.CodiceProvincia = elementoRigaComune[5];
    objComune.CodiceComune = elementoRigaComune[6];
    objComune.Abitanti = Convert.ToInt32(elementoRigaComune[7]);
    objComune.Link = elementoRigaComune[8];

    comune.Add(objComune);

}

int totAbitanti = 0;
foreach (var com in comune)
{
    if (com.Provincia == "TO" )
        totAbitanti += com.Abitanti;
}

int totAbitanti2 = comune.Where(s => s.Provincia == "TO").Sum(x => x.Abitanti);


int totAbitantiTORINO = comune.Where(s => s.Provincia == "TO").Sum(x => x.Abitanti);
int totAbitantiMILANO = comune.Where(s => s.Provincia == "MI").Sum(x => x.Abitanti);
int totAbitantiTORINOMILANO = comune.Where(s => s.Provincia == "MI" || s.Provincia == "TO").Sum(x => x.Abitanti);

//quanti comuni in piemonte
int totAbitantiPiemonte = comune.Where(s => s.Regione == "PIE").Count();
int totAbitantiPiemonte1000 = comune.Where(s => s.Regione == "PIE" && s.Abitanti>=1000).Count();

//comune con meno abitanti
var comuneMenoAbitanti = comune
    .Where(s => s.Regione == "PIE")
    .OrderBy(s => s.Abitanti)
    .First();
Console.WriteLine($"Il comune con meno abitanti è {comuneMenoAbitanti.NomeComune}  e ha {comuneMenoAbitanti.Abitanti} abitanti ");

//comuni che inizion con A
int totAbitantiPiemonteA = comune.Where(s => s.NomeComune.Substring(0,1)=="A" ).Count();
int totAbitantiPiemonteA1 = comune.Where(s => s.NomeComune.ToUpper().StartsWith ( "A")).Count();
int totAbitantiPiemonteA2 = comune.Where(s => s.NomeComune.EndsWith("A",StringComparison.InvariantCultureIgnoreCase) ).Count();
int totAbitantiPiemonteA3 = comune.Where(s => s.NomeComune.ToUpper().Contains("A") ).Count();





Console.WriteLine(totAbitanti);
Console.WriteLine(totAbitanti2);
