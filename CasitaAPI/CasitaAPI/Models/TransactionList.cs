using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class TransactionList
{
    public int Id { get; set; }

    public decimal? AmountSpent { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public string? Name { get; set; }

    public int? SpentTypeId { get; set; }

    public string? FinantialId { get; set; }

    public string? PhotoUrl { get; set; }

    public int? PriorityId { get; set; }

    public int? ListTypeD { get; set; }

    public virtual Financial? Finantial { get; set; }

    public virtual ICollection<ListItem> ListItems { get; set; } = new List<ListItem>();

    public virtual ListType? ListTypeDNavigation { get; set; }

    public virtual Priority? Priority { get; set; }

    public virtual SpentType? SpentType { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
