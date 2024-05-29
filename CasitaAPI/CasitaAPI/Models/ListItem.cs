using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class ListItem
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsConcluded { get; set; }

    public int ListId { get; set; }

    public int PriorityId { get; set; }

    public decimal? Value { get; set; }

    public virtual TransactionList List { get; set; } = null!;

    public virtual Priority Priority { get; set; } = null!;
}
