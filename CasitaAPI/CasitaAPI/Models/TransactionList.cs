using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class TransactionList
{
    public Guid Id { get; set; }

    public decimal AmountSpent { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string Name { get; set; } = null!;

    public Guid? FinantialId { get; set; }

    public string? PhotoUrl { get; set; }

    public Guid? PriorityId { get; set; }

    public Guid? ListTypeId { get; set; }

    public DateOnly? RenovationDate { get; set; }

    public virtual Financial? Finantial { get; set; }

    public virtual ICollection<ListItem> ListItems { get; set; } = new List<ListItem>();

    public virtual ListType? ListType { get; set; }

    public virtual Priority? Priority { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
