using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class WorkoutDayDetail
{
    public uint WorkoutDayId { get; set; }

    public uint WorkoutId { get; set; }

    public string WorkoutDayName { get; set; } = null!;

    public decimal? WorkoutWeight { get; set; }

    public uint Reps { get; set; }

    public uint Sets { get; set; }

    public virtual Workout Workout { get; set; } = null!;

    public virtual WorkoutDay WorkoutDay { get; set; } = null!;
}
