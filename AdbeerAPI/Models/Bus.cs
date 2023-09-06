using System;
using System.Collections.Generic;

namespace AdbeerAPI.Models;

public partial class Bus
{
    public int Id { get; set; }

    public int Capacity { get; set; }

    public int DriverId { get; set; }

    public int SchoolId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public int? SortId { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<BusStudent> BusStudents { get; set; } = new List<BusStudent>();

    public virtual Driver Driver { get; set; } = null!;

    public virtual School School { get; set; } = null!;
}
