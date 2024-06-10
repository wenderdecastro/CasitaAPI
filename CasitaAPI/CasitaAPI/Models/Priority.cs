using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class Priority
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<ListItem> ListItems { get; set; } = new List<ListItem>();

    public virtual ICollection<TransactionList> TransactionLists { get; set; } = new List<TransactionList>();
}
