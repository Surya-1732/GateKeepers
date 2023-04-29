using System;
using System.Collections.Generic;

namespace Energy.Models;

public partial class Consumption
{
    public int Id { get; set; }

    public int ApplianceId { get; set; }

    public double UnitsConsumed { get; set; }

    public DateTime CreatedDateTime { get; set; }
}
