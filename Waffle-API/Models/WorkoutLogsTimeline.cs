using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class WorkoutLogsTimeline
{
    public uint UserId { get; set; }

    public uint WorkoutLogId { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual WorkoutLog WorkoutLog { get; set; } = null!;
}
