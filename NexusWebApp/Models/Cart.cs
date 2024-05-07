using System;
using System.Collections.Generic;

namespace NexusWebApp.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? CustomerId { get; set; }

    public virtual InforUser? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
