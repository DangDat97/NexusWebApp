using System;
using System.Collections.Generic;

namespace NexusWebApp.Models;

public partial class Review
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string? Coment { get; set; }

    public int? ProductId { get; set; }

    public DateOnly? CrateAt { get; set; }

    public virtual InforUser? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
