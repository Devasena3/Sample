using System;
using System.Collections.Generic;

namespace Project.Domain.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string? StudentName { get; set; }

    public string? RollNo { get; set; }

    public string? ClassName { get; set; }

    public string? FeesCategory { get; set; }

    public decimal? FeesAmount { get; set; }

    public string? PaymentStaus { get; set; }

    public bool? DeleteFlag { get; set; }
}
