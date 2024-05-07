using System;
using System.Collections.Generic;

namespace NexusWebApp.Models;

public partial class Booking
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ConnectionId { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Message { get; set; }

    public byte? Status { get; set; }

    public virtual Connection? Connection { get; set; }
}
