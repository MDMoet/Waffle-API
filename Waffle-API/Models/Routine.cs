using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class Routine
{
    public uint RoutineId { get; set; }

    public uint UserId { get; set; }

    public virtual ICollection<SelectedRoutine> SelectedRoutines { get; set; } = new List<SelectedRoutine>();

    public virtual User User { get; set; } = null!;
}
