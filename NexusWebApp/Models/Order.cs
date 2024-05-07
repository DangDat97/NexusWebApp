using System;
using System.Collections.Generic;

namespace NexusWebApp.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public decimal? TotalInvoice { get; set; }

    public byte? Status { get; set; }

    public DateOnly? CrateAt { get; set; }

    public virtual InforUser? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
