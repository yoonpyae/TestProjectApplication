using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string? CustomerName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }
}
