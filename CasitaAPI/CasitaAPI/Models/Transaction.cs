using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public decimal? Value { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Name { get; set; }

    public int? ListId { get; set; }

    public int? FrequencyId { get; set; }

    public int? TransactionTypeId { get; set; }

    public virtual Frequency? Frequency { get; set; }

    public virtual TransactionList? List { get; set; }

    public virtual TransactionType? TransactionType { get; set; }
}
