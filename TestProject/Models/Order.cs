using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public DateOnly? OrderDate { get; set; }

    public int? Quantity { get; set; }

    public string? CustomerId { get; set; }

    public string? ProductId { get; set; }

    public double? TotalAmount { get; set; }
}
