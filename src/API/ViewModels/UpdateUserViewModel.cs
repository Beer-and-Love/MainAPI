using System.ComponentModel.DataAnnotations;
using Domain.Enuns;
using Domain.Entities;
namespace API.ViewModels
{
    public class UpdateUserViewModel
    {


        [Required(ErrorMessage = "O id não pode ser vazio")]
        [Range(1, int.MaxValue, ErrorMessage = "O id deve ter no mínimo 1 dígito.")]
        public int Id { get; set; }


        [Required(ErrorMessage = "O nome não pode ser vazio")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "O Email não pode ser vazio")]
        [MinLength(10, ErrorMessage = "O Email deve ter no mínimo 10 caracteres.")]
        [MaxLength(180, ErrorMessage = "O Email deve ter no máximo 180 caracteres.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "A senha não pode ser vazia")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        [MaxLength(80, ErrorMessage = "A senha deve ter no máximo 80 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "A cidade não pode ser vazio")]
        [MaxLength(180, ErrorMessage = "A cidade deve ter no máximo 180 caracteres.")]
        public string City { get; set; }

        [Required(ErrorMessage = "As informações não podem ser vazias")]
        [MaxLength(250, ErrorMessage = "As informações devem ter no máximo 250 caracteres.")]
        public string Informations { get; set; }



        [EnumDataType(typeof(Status), ErrorMessage = "O valor do status é inválido")]
        public Status? Status { get; set; }


        [Required(ErrorMessage = "A localização é obrigatória")]
        public Localization? Localization { get; set; }
    }
}