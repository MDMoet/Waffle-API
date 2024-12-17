using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class WeightLogsTimeline
{
    public uint UserId { get; set; }

    public uint WeightLogId { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual WeightLog WeightLog { get; set; } = null!;
}
