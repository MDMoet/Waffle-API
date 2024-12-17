using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class RoutineDetail
{
    public uint RoutineId { get; set; }

    public uint WeekDayId { get; set; }

    public uint WorkoutDayId { get; set; }

    public uint WorkoutAfterId { get; set; }

    public virtual Routine Routine { get; set; } = null!;

    public virtual WeekDay WeekDay { get; set; } = null!;

    public virtual WorkoutDayAfter WorkoutAfter { get; set; } = null!;

    public virtual WorkoutDay WorkoutDay { get; set; } = null!;
}
