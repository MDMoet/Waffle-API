using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class WeekDay
{
    public uint WeekDayId { get; set; }

    public string DayName { get; set; } = null!;
}
