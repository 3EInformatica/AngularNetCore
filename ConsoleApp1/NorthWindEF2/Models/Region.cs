﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace NorthWindEF2.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; }

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}