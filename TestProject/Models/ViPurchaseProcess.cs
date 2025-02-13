using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class ViPurchaseProcess
{
    public string PurchaseId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public double? Amount { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public int? Quantity { get; set; }

    public string? ProductName { get; set; }

    public string PurchaseDetailId { get; set; } = null!;

    public string? CustomerName { get; set; }
}
