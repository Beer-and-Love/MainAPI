using Domain.Validators;
using Domain.Exceptions;
using Domain.Enuns;

namespace Domain.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Informations { get; set; }
        public Localization? Localization { get; set; }
        public Status? Status { get; set; }

        public User() { }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();

            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                throw new DomainException("Alguns campos estão inválidos, por favor corrigir", _errors);
            }
            return true;
        }
    }
}