using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class Transaction
{
    public Guid Id { get; set; }

    public decimal? Value { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Name { get; set; }

    public Guid? ListId { get; set; }

    public Guid? FrequencyId { get; set; }

    public virtual Frequency? Frequency { get; set; }

    public virtual TransactionList? List { get; set; }
}
