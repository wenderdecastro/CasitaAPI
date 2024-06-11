using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CasitaAPI.ViewModels
{
    public class UserViewModel
    {
            [NotMapped]
            [JsonIgnore]
            public IFormFile? Arquivo { get; set; }
            public string? Foto { get; set; }
        
    }
}
