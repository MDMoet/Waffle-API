using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class WorkoutLog
{
    public uint WorkoutLogId { get; set; }

    public uint WorkoutId { get; set; }

    public decimal Weight { get; set; }

    public uint Reps { get; set; }

    public virtual Workout Workout { get; set; } = null!;

    public virtual ICollection<WorkoutLogsTimeline> WorkoutLogsTimelines { get; set; } = new List<WorkoutLogsTimeline>();
}
