using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Bussines.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
        }
    }
}
