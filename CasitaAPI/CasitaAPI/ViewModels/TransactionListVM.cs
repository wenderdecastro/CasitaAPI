using CasitaAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CasitaAPI.ViewModels
{
    public class TransactionListVM
    {

        public decimal? TotalAmount { get; set; }

        public string Name { get; set; } = null!;

        public Guid? FinantialId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? Photo { get; set; }



    }
}
