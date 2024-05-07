using System;
using System.Collections.Generic;

namespace NexusWebApp.Models;

public partial class Distributor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
