using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class Frequency
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
