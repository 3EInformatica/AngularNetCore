﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace NorthWindEF2.Models;

public partial class LogAccessi
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime DataTentativo { get; set; }

    public bool Esito { get; set; }

    public string DaDove { get; set; }
}