using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class Goal
{
    public uint GoalId { get; set; }

    public uint UserId { get; set; }

    public uint WorkoutId { get; set; }

    public decimal GoalWeight { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Workout Workout { get; set; } = null!;
}
