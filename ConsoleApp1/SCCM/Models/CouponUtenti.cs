﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SCCM.Models;

public partial class CouponUtenti
{
    public int Id { get; set; }

    public DateTime DataCreazione { get; set; }

    public DateTime? DataAggiornamento { get; set; }

    public bool Abilitato { get; set; }

    public DateTime? DataCancellazione { get; set; }

    public string Email { get; set; }

    public string CodiceCoupon { get; set; }

    public DateTime DataScadenza { get; set; }

    public DateTime? DataUtilizzo { get; set; }
}