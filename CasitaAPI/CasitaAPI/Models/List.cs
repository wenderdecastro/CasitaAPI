using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class List
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AppTask> AppTasks { get; set; } = new List<AppTask>();

    public virtual User User { get; set; } = null!;
}
