using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderValidatorPOC.BuilderValidator
{
    public interface IValidatorBuilder
    {
        IValidatorBuilder ValidateName(string name);
        IValidatorBuilder ValidateEmailAddress(string emailAddress);
        IValidatorBuilder ValidateAge(int age);
        bool Validate();
    }
}
