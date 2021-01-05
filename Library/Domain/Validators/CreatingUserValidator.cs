using FluentValidation;
using Library.Domain.Entities.User;

namespace Library.Domain.Validators
{
    public class CreatingUserValidator : AbstractValidator<User>
    {
        public CreatingUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("User must have a name");
        }
    }
}
