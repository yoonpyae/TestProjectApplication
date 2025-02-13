using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string? Price { get; set; }

    public string? CustomerId { get; set; }
}
