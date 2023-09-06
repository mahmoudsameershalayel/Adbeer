using System;
using System.Collections.Generic;

namespace AdbeerAPI.Models;

public partial class Notification
{
    public int Id { get; set; }

    public string SenderId { get; set; } = null!;

    public string SenderId1 { get; set; } = null!;

    public string ReceiverId { get; set; } = null!;

    public int SchoolId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime SendingTime { get; set; }

    public virtual School School { get; set; } = null!;

    public virtual AspNetUser SenderId1Navigation { get; set; } = null!;
}
