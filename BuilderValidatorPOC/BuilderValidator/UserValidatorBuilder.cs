using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BuilderValidatorPOC.BuilderValidator
{
    public class UserValidatorBuilder : IValidatorBuilder
    {
        private List<bool> _validationResults { get; }
        private Regex _emailValidatorRegex;
        private Regex _nameValidatorRegex;

        public UserValidatorBuilder(List<bool> validationResult, string emailRegexString, string nameRegexString)
        {
            _validationResults = validationResult;
            _emailValidatorRegex = new Regex(emailRegexString);
            _nameValidatorRegex = new Regex(nameRegexString);
        }

        public IValidatorBuilder ValidateAge(int age)
        {
            var ageIsValid = age > 0 && age < 100;
            _validationResults.Add(ageIsValid);
            return this;
        }

        public IValidatorBuilder ValidateEmailAddress(string emailAddress)
        {
            var emailExists = !string.IsNullOrEmpty(emailAddress);
            var emailIsValid = _emailValidatorRegex.Match(emailAddress).Success;
            _validationResults.Add(emailExists && emailIsValid);
            return this;
        }

        public IValidatorBuilder ValidateName(string name)
        {
            var nameExists = !string.IsNullOrEmpty(name);
            var nameIsValid = _nameValidatorRegex.Match(name).Success;
            _validationResults.Add(nameExists && nameIsValid);
            return this;
        }

        public bool Validate()
        {
            var validationResult = _validationResults.All(x => x);
            _validationResults.Clear();
            return validationResult;
        }
    }
}
