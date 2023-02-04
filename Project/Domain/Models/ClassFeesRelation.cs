using System;
using System.Collections.Generic;

namespace Project.Domain.Models;

public partial class ClassFeesRelation
{
    public int Id { get; set; }

    public string? ClassName { get; set; }

    public string? Feescategory { get; set; }

    public bool? DeleteFlag { get; set; }
}
