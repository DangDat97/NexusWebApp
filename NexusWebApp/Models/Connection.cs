using System;
using System.Collections.Generic;

namespace NexusWebApp.Models;

public partial class Connection
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? ConnectionTypeId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ConnectionType? ConnectionType { get; set; }
}
