﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SCCM.Models;

public partial class AnagraficheClienti
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Cognome { get; set; }

    public string CodiceFiscale { get; set; }

    public DateTime? DataNascita { get; set; }

    public int IdUtenza { get; set; }

    public DateTime DataCreazione { get; set; }

    public DateTime? DataAggiornamento { get; set; }

    public int? IdUtenzaModifica { get; set; }

    public int? Altezza { get; set; }

    public string Cap { get; set; }

    public string Citta { get; set; }

    public string Indirizzo { get; set; }

    public string Nazionalita { get; set; }

    public string Paese { get; set; }

    public int? Sesso { get; set; }

    public string Telefono { get; set; }

    public bool Confermato { get; set; }

    public bool QuestionarioCompleto { get; set; }

    public int? PunteggioQuestionario { get; set; }

    public string TokenQuestionario { get; set; }

    public bool Abilitato { get; set; }

    public DateTime? DataCancellazione { get; set; }

    public string Provincia { get; set; }

    public string KeyProvenienza { get; set; }

    public string CittaNascita { get; set; }

    public string ProvinciaNascita { get; set; }

    public int? ExternalCode { get; set; }

    public bool? Privacy1 { get; set; }

    public bool? Privacy2 { get; set; }

    public bool? Privacy3 { get; set; }

    public bool PrimoPagamento { get; set; }

    public bool MediciAssegnati { get; set; }

    public bool RegisterStep2 { get; set; }

    public string Coupon { get; set; }

    public virtual StatistichePesoClienti StatistichePesoClienti { get; set; }
}