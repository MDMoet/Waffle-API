using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class WorkoutDetail
{
    public uint WorkoutId { get; set; }

    public uint MuscleId { get; set; }

    public uint TypeId { get; set; }

    public uint EquipmentId { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual Muscle Muscle { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;

    public virtual Workout Workout { get; set; } = null!;
}
