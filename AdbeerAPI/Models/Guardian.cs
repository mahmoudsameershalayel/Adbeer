using System;
using System.Collections.Generic;

namespace AdbeerAPI.Models;

public partial class Guardian
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
