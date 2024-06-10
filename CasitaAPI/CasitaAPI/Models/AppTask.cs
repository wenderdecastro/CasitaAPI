using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class AppTask
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? PriorityId { get; set; }

    public int? ListId { get; set; }

    public string? Description { get; set; }

    public DateOnly? DueDate { get; set; }

    public bool? IsConcluded { get; set; }

    public int? FrequencyId { get; set; }

    public DateTime? ConcludedDate { get; set; }

    public string Name { get; set; } = null!;

    public TimeOnly? DueTime { get; set; }

    public DateOnly? ResetDate { get; set; }

    public virtual Frequency? Frequency { get; set; }

    public virtual AppList? List { get; set; }
}
