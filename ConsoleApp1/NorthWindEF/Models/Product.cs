﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using NorthWindEF.Request;
using System;
using System.Collections.Generic;

namespace NorthWindEF.Models;

public partial class Product: ProductRequest
{
    

    public virtual Category Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Supplier Supplier { get; set; }
}