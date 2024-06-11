using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? RecoveryCode { get; set; }

    public DateOnly CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AppList> AppLists { get; set; } = new List<AppList>();

    public virtual Financial IdNavigation { get; set; } = null!;
}
