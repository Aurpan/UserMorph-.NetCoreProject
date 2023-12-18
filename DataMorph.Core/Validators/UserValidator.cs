using FluentValidation;
using UserMorph.Core.DTOs.DomainModels;

namespace UserMorph.Core.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(u => u.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(u => u.Company)
                .MaximumLength(200);

            RuleFor(u => u.Sex)
                .IsInEnum();

            
        }
    }
}
