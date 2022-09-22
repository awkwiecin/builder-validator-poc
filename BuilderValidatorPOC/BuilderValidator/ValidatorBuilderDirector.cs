using BuilderValidatorPOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderValidatorPOC.BuilderValidator
{
    public class ValidatorBuilderDirector
    {
        private IValidatorBuilder _builder;

        public ValidatorBuilderDirector(IValidatorBuilder builder)
        {
            _builder = builder;
        }

        public bool ValidateAll (User user)
        {
            return _builder.ValidateAge(user.Age)
                           .ValidateEmailAddress(user.Email)
                           .ValidateName(user.FirstName)
                           .ValidateName(user.LastName)
                           .Validate();
        }

        public bool ValidateNames(User user)
        {
            return _builder.ValidateName(user.FirstName)
                           .ValidateName(user.LastName)
                           .Validate();
        }

        public bool ValidateAgeAndEmail(User user)
        {
            return _builder.ValidateAge(user.Age)
                           .ValidateEmailAddress(user.Email)
                           .Validate();
        }
    }
}
