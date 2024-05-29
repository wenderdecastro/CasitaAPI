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

    public DateTime? DueDate { get; set; }

    public int? StatusId { get; set; }

    public int? FrequencyId { get; set; }

    public virtual List? List { get; set; }

    public virtual Status? Status { get; set; }
}
