using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class Status
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<AppTask> AppTasks { get; set; } = new List<AppTask>();
}
