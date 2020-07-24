using System.Collections.Generic;
using AGL.Application.Common.Models;
using AGL.Domain.Model;
using FluentValidation;

namespace AGL.Application.Validators
{

    public class PersonListValidator : AbstractValidator<List<PersonDto>>
    {
        public PersonListValidator()
        {
            RuleForEach(p => p).SetValidator(new PersonValidator());
        }
    }

    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Name Can not be null").MaximumLength(20).WithMessage("Person Name could not be longer than 20 characters.")
                .Matches("[a-zA-Z]").WithMessage("Name can not have non-Alphabet character.");

            RuleFor(p => p.Gender).NotNull().MaximumLength(10).WithMessage("Person's Gender can not be more than 10 character");

            RuleFor(p => p.Age).NotNull().WithMessage("Age Can not be null.");

            RuleForEach(p => p.Pets).SetValidator(new PetValidator());

        }
    }


}

