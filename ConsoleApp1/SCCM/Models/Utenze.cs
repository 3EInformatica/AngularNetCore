﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SCCM.Models;

public partial class Utenze
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public int TipoUtente { get; set; }

    public DateTime DataCreazione { get; set; }

    public DateTime? DataAggiornamento { get; set; }

    public bool Abilitato { get; set; }

    public DateTime? DataCancellazione { get; set; }

    public string Username { get; set; }

    public string ClearPassword { get; set; }

    public string FotoProfilo { get; set; }

    public virtual ICollection<AnagraficheGestori> AnagraficheGestoris { get; set; } = new List<AnagraficheGestori>();

    public virtual ICollection<AnagraficheMedici> AnagraficheMedicis { get; set; } = new List<AnagraficheMedici>();
}