using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class User
{
    public uint UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte EmailVerified { get; set; }

    public string Password { get; set; } = null!;

    public string? RememberToken { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<Routine> Routines { get; set; } = new List<Routine>();

    public virtual SelectedRoutine? SelectedRoutine { get; set; }

    public virtual ICollection<WeightLogsTimeline> WeightLogsTimelines { get; set; } = new List<WeightLogsTimeline>();

    public virtual ICollection<WorkoutDayAfter> WorkoutDayAfters { get; set; } = new List<WorkoutDayAfter>();

    public virtual ICollection<WorkoutDay> WorkoutDays { get; set; } = new List<WorkoutDay>();

    public virtual ICollection<WorkoutLogsTimeline> WorkoutLogsTimelines { get; set; } = new List<WorkoutLogsTimeline>();
}
