using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O Login não pode ser vazio")]
        public string Email { get; set; }


        [Required(ErrorMessage = "A Senha não pode ser vazio")]
        public string Password { get; set; }
    }
}