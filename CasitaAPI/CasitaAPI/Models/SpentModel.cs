using System;
using System.Collections.Generic;

namespace CasitaAPI.Models;

public partial class SpentModel
{
    public int Id { get; set; }

    public decimal NecessitiesPercentage { get; set; }

    public decimal WantsPercentage { get; set; }

    public decimal SavingsPercentage { get; set; }

    public virtual ICollection<Financial> Financials { get; set; } = new List<Financial>();
}
