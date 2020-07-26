using AGL.Domain.Model;
using FluentValidation;

namespace AGL.Application.Validators
{
    public class PetValidator : AbstractValidator<Pet>
    {
        public PetValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Pet's Can not be null").MaximumLength(20).
                WithMessage("Pet's Name could not be longer than 20 characters.");
            RuleFor(p => p.Type).NotNull().MaximumLength(20);
        }
    }
}
