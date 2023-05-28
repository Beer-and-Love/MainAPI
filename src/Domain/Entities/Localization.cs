using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Exceptions;
using Domain.Validators;

namespace Domain.Entities
{
    public class Localization : Base
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

         public override bool Validate()
        {
            var validator = new LocalizationValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                throw new DomainException("Campos inválidos, por favor corrigir" , _errors);
            }
            return true;
        }
    }

}