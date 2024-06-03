using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class Financial
{
    public Guid Id { get; set; }

    public DateOnly? ReceiptDate { get; set; }

    public decimal Balance { get; set; }

    public decimal NecessitiesPercentage { get; set; }

    public decimal SavingsPercentage { get; set; }

    public decimal WantsPercentage { get; set; }

    public virtual ICollection<TransactionList> TransactionLists { get; set; } = new List<TransactionList>();

    public virtual User? User { get; set; }
}
