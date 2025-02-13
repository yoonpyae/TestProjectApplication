using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Purchase
{
    public string PurchaseId { get; set; } = null!;

    public DateOnly? PurchaseDate { get; set; }
}
