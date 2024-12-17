using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class Workout
{
    public uint WorkoutId { get; set; }

    public string WorkoutName { get; set; } = null!;

    public string? WorkoutImgPath { get; set; }

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();
}
