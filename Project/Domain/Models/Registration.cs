using System;
using System.Collections.Generic;

namespace Project.Domain.Models;

public partial class Registration
{
    public int Id { get; set; }

    public string? StudentName { get; set; }

    public string? RollNo { get; set; }

    public string? ParentName { get; set; }

    public string? ClassName { get; set; }

    public string? ContactNo { get; set; }

    public string? Address { get; set; }

    public bool? DeleteFlag { get; set; }
}
