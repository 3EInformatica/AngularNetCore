﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SCCM.Models;

public partial class OtpToken
{
    public int Id { get; set; }

    public string Token { get; set; }

    public DateTime? DataScadenza { get; set; }

    public string TipoToken { get; set; }

    public string Data { get; set; }

    public DateTime DataCreazione { get; set; }

    public DateTime? DataAggiornamento { get; set; }

    public bool Consumato { get; set; }

    public bool Abilitato { get; set; }

    public DateTime? DataCancellazione { get; set; }
}