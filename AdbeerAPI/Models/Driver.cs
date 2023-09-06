using System;
using System.Collections.Generic;

namespace AdbeerAPI.Models;

public partial class Driver
{
    public string ApplicationUserId { get; set; } = null!;

    public int SchoolId { get; set; }

    public int Id { get; set; }

    public virtual AspNetUser ApplicationUser { get; set; } = null!;

    public virtual Bus? Bus { get; set; }

    public virtual ICollection<BusStudent> BusStudents { get; set; } = new List<BusStudent>();

    public virtual School School { get; set; } = null!;
}
