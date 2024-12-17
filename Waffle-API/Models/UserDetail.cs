using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class UserDetail
{
    public uint UserId { get; set; }

    public decimal Weight { get; set; }

    public decimal FatMass { get; set; }

    public decimal MuscleMass { get; set; }

    public decimal Height { get; set; }

    public string Gender { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public string System { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
