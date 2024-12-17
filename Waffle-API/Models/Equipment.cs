using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class Equipment
{
    public uint EquipmentId { get; set; }

    public string EquipmentName { get; set; } = null!;

    public string? EquipmentImgPath { get; set; }
}
