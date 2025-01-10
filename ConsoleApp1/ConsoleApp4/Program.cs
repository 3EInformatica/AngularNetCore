using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using ConsoleApp4.Common;
using ConsoleApp4.Models;




List<Corsi> listaCorsi = new List<Corsi>();

string contenutoFile = System.IO.File.ReadAllText(Costanti.pathFileToRead);
var vettoreCorsi = contenutoFile.Split("\r\n");

foreach (var rigaCorso in vettoreCorsi.Skip(1))
{

    var elementoRigaCorso = rigaCorso.Split(Costanti.separatore);
    //VALIDAZIONE

    //var esito= Guid.TryParse(elementoRigaCorso[0], out Guid guid);
    //if (esito== false)
    //{
    //    Console.WriteLine($"Errore in {elementoRigaCorso[0]}");
    //    continue;
    //}
    //ConsoleApp4.Common.Validator objValidator = new ConsoleApp4.Common.Validator(); 
    //objValidator.ValidateGuid(elementoRigaCorso[0]);
    if (!ConsoleApp4.Common.Validator.ValidateGuid(elementoRigaCorso[0]))
    {
        System.IO.File.AppendAllText(Costanti.pathFileToWriteKO, rigaCorso);
        continue;
    }
    ///sequenza
    if (!ConsoleApp4.Common.Validator.ValidateInt(elementoRigaCorso[1]))
    {
        continue;
    }
    if (ConsoleApp4.Common.Validator.ValidateDateTime(elementoRigaCorso[8]) == false)
    {
        continue;
    }
    if (ConsoleApp4.Common.Validator.ValidateDateTime(elementoRigaCorso[9]) == false)
    {
        continue;
    }
    if (ConsoleApp4.Common.Validator.ValidateInt(elementoRigaCorso[13]) == false)
    {
        continue;
    }
    if (ConsoleApp4.Common.Validator.ValidateInt(elementoRigaCorso[14]) == false)
    {
        continue;
    }
    //if (ConsoleApp4.Common.Validator.ValidateBool(elementoRigaCorso[15]) == false)
    //{
    //    continue;
    //}
    //if (ConsoleApp4.Common.Validator.ValidateBool(elementoRigaCorso[16]) == false)
    //{
    //    continue;
    //}
    //if (ConsoleApp4.Common.Validator.ValidatorEmail(elementoRigaCorso[4]) == false)
    //{
    //    continue;
    //}
    if (
           !ConsoleApp4.Common.Validator.ValidateBool(elementoRigaCorso[15])
        || !ConsoleApp4.Common.Validator.ValidateBool(elementoRigaCorso[16])
        || !ConsoleApp4.Common.Validator.ValidatorEmail(elementoRigaCorso[4])
        )
    {
        continue;
    }

    //Fine validazione
    Corsi c = new Corsi();
    c.Guid = Guid.Parse(elementoRigaCorso[0]);
    c.Sequenza = Convert.ToInt32(elementoRigaCorso[1]);
    c.Autore = elementoRigaCorso[5];
    c.Crediti = Convert.ToInt32(elementoRigaCorso[14]);
    c.DataFine = Convert.ToDateTime(elementoRigaCorso[9]);
    c.EmailContatto = elementoRigaCorso[4];
    c.Icona = elementoRigaCorso[10];
    c.ModuliOre = Convert.ToInt32(elementoRigaCorso[13]);
    c.RichiediAccettazione = Convertitori.ConvertiBool(elementoRigaCorso[15]);
    if (elementoRigaCorso[16] == "0")
    {
        c.InviaNotificaEmail = false;
    }
    else
    {
        c.InviaNotificaEmail = true;
    }
    c.InviaNotificaEmail = (elementoRigaCorso[16] == "0") ? false : true;

    listaCorsi.Add(c);
   
}

string contenuto = "";
foreach (var corso in listaCorsi)
{
    contenuto += corso.Guid +";"
        +corso.Sequenza + ";"
        + corso.Codice + ";"
        + corso.Titolo + ";"
        + corso.EmailContatto + ";"
        + corso.Autore + ";"
        + "\n";
}   
File.WriteAllText(Costanti. pathFileToWrite
    , contenuto);

Console.WriteLine("Funziona!");

