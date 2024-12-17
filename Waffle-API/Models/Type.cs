using System;
using System.Collections.Generic;

namespace Waffle_API.Models;

public partial class Type
{
    public uint TypeId { get; set; }

    public string TypeName { get; set; } = null!;
}
