using System;
using System.Collections.Generic;

namespace Energy.Models;

public partial class Cost
{
    public int Id { get; set; }

    public int Unit { get; set; }

    public double Price { get; set; }

    public DateTime CreatedDateTime { get; set; }
}
