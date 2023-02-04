using System;
using System.Collections.Generic;

namespace Project.Domain.Models;

public partial class FeesCategory
{
    public int Id { get; set; }

    public string? FeesCategory1 { get; set; }

    public decimal? FeesAmount { get; set; }

    public bool? DeleteFlag { get; set; }
}
