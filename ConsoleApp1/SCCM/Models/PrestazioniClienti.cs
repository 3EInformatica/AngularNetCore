﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SCCM.Models;

public partial class PrestazioniClienti
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int IdPrestazione { get; set; }

    public DateTime? DataInizioEffettivo { get; set; }

    public DateTime? DataFineEffettivo { get; set; }

    public DateTime? DataInizioCliente { get; set; }

    public DateTime? DataFineCliente { get; set; }

    public DateTime? DataInizioMedico { get; set; }

    public DateTime? DataFineMedico { get; set; }

    public DateTime? ScadenzaPrestazione { get; set; }

    public bool? Eseguito { get; set; }

    public DateTime DataCreazione { get; set; }

    public DateTime? DataAggiornamento { get; set; }

    public bool Abilitato { get; set; }

    public DateTime? DataCancellazione { get; set; }

    public Guid GuidCp { get; set; }
}