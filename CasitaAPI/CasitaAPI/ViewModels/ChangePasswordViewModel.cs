using System.ComponentModel.DataAnnotations;

namespace CasitaAPI.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Informe a nova senha do usuário")]
        public string? SenhaNova { get; set; }
    }
}
