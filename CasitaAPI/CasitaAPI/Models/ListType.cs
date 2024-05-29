using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class ListType
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TransactionList> TransactionLists { get; set; } = new List<TransactionList>();
}
