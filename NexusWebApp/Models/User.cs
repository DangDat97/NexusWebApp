using System;
using System.Collections.Generic;

namespace NexusWebApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte Level { get; set; }

    public bool? Status { get; set; }

    public string? RandomKey { get; set; }

    public virtual ICollection<InforUser> InforUsers { get; set; } = new List<InforUser>();
}
