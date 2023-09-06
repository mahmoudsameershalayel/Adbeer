using System;
using System.Collections.Generic;

namespace AdbeerAPI.Models;

public partial class Administrator
{
    public int Id { get; set; }

    public string? ApplicationUserId { get; set; }

    public virtual School? School { get; set; }
}
