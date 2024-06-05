using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class AppList
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? ListTypeId { get; set; }

    public virtual ICollection<AppTask> AppTasks { get; set; } = new List<AppTask>();

    public virtual ListType? ListType { get; set; }

    public virtual User User { get; set; } = null!;
}
