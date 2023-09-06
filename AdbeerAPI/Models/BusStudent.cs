using System;
using System.Collections.Generic;

namespace AdbeerAPI.Models;

public partial class BusStudent
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int BusId { get; set; }

    public int? DriverId { get; set; }

    public virtual Bus Bus { get; set; } = null!;

    public virtual Driver? Driver { get; set; }

    public virtual Student Student { get; set; } = null!;
}
