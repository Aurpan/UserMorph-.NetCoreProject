using FluentValidation;
using UserMorph.Core.DTOs.DomainModels;

namespace UserMorph.Core.Validators
{
    public class ContactValidator: AbstractValidator<UserContact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.Phone)
            .NotEmpty().WithMessage("Phone number cannot be empty")
            .Matches(@"^\d{11}$")
            .WithMessage("Invalid phone number format.");

            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Address cannot be empty")
                .MaximumLength(200);

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("City cannot be empty")
                .MaximumLength(200);

            RuleFor(c => c.Country)
                .NotEmpty().WithMessage("Country cannot be empty")
                .MaximumLength(200);
        }
    }
}
