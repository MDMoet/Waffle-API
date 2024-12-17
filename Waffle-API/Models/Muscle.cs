using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class Muscle
{
    public uint MuscleId { get; set; }

    public string MuscleName { get; set; } = null!;

    public string? MuscleImgPath { get; set; }
}
