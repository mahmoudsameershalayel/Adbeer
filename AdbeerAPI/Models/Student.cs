using System;
using System.Collections.Generic;

namespace AdbeerAPI.Models;

public partial class Student
{
    public string ApplicationUserId { get; set; } = null!;

    public int SchoolId { get; set; }

    public int Id { get; set; }

    public int GuardianId { get; set; }

    public virtual AspNetUser ApplicationUser { get; set; } = null!;

    public virtual ICollection<BusStudent> BusStudents { get; set; } = new List<BusStudent>();

    public virtual Guardian Guardian { get; set; } = null!;

    public virtual School School { get; set; } = null!;
}
