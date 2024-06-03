using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? RecoveryCode { get; set; }

    public string? PhotoUrl { get; set; }

    public DateOnly CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Financial UserFinancial { get; set; } = null!;

    public virtual ICollection<List> Lists { get; set; } = new List<List>();
}
