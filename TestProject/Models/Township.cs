using System;
using System.Collections.Generic;

namespace TestProject.Models;

public partial class Township
{
    public string TownshipId { get; set; } = null!;

    public string? TownshipName { get; set; }

    public string? Latitude { get; set; }
}
