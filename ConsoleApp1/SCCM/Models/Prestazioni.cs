﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SCCM.Models;

public partial class Prestazioni
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Professione { get; set; }

    public DateTime DataCreazione { get; set; }

    public DateTime? DataAggiornamento { get; set; }

    public bool Abilitato { get; set; }

    public DateTime? DataCancellazione { get; set; }

    public int? Durata { get; set; }
}