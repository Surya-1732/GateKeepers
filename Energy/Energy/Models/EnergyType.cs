using System;
using System.Collections.Generic;

namespace Energy.Models;

public partial class EnergyType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double EnergyConsumed { get; set; }

    public DateTime CreatedDateTime { get; set; }
}
