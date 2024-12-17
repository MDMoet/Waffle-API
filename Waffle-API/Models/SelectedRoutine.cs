using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class SelectedRoutine
{
    public uint UserId { get; set; }

    public uint RoutineId { get; set; }

    public virtual Routine Routine { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
