using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class WorkoutDayAfterDetail
{
    public uint WorkoutAfterId { get; set; }

    public uint WorkoutId { get; set; }

    public decimal Weight { get; set; }

    public TimeOnly WorkoutTime { get; set; }

    public virtual Workout Workout { get; set; } = null!;

    public virtual WorkoutDayAfter WorkoutAfter { get; set; } = null!;
}
