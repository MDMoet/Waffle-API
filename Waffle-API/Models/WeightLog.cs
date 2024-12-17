using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class WeightLog
{
    public uint WeightLogId { get; set; }

    public decimal WeightLog1 { get; set; }

    public decimal FatMassLog { get; set; }

    public decimal MuscleMassLog { get; set; }

    public DateOnly UpdatedAt { get; set; }

    public virtual ICollection<WeightLogsTimeline> WeightLogsTimelines { get; set; } = new List<WeightLogsTimeline>();
}
