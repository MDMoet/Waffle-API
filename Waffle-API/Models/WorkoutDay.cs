using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class WorkoutDay
{
    public uint WorkoutDayId { get; set; }

    public uint UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
