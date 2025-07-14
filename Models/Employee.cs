using System;
using System.Collections.Generic;

namespace WebApiCoreCruds1.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public string? Qualification { get; set; }
}
