using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class ListType
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<AppList> AppLists { get; set; } = new List<AppList>();

    public virtual ICollection<TransactionList> TransactionLists { get; set; } = new List<TransactionList>();
}
