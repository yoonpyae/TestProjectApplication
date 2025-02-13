using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Supplier
{
    public string SupplierId { get; set; } = null!;

    public string? SupplierName { get; set; }

    public string? PhoneNo { get; set; }

    public string? Address { get; set; }
}
