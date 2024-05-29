using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class Financial
{
    public string Id { get; set; } = null!;

    public DateOnly? ReceiptDate { get; set; }

    public decimal? Balance { get; set; }

    public int? SpentModelId { get; set; }

    public virtual SpentModel? SpentModel { get; set; }

    public virtual ICollection<TransactionList> TransactionLists { get; set; } = new List<TransactionList>();

    public virtual User? User { get; set; }
}
