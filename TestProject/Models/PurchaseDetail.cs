using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class PurchaseDetail
{
    public string PurchaseDetailId { get; set; } = null!;

    public string? PurchaseId { get; set; }

    public string? ProductId { get; set; }

    public double? Amount { get; set; }

    public int? Quantity { get; set; }
}
