using System;
using System.Collections.Generic;

namespace NexusWebApp.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string? Name { get; set; }

    public virtual Product? Product { get; set; }
}
