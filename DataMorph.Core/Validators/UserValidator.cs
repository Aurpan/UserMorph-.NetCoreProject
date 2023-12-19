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



            RuleFor(u => u.Contacts)
                .Must(contacts => contacts.All(c => new ContactValidator().Validate(c).IsValid))
                .When(u => u.Contacts.Any())
                .WithMessage("Inalid contact(s)");



            RuleFor(u => u.Roles)
                .Must(role => role.All(r => new RoleValidator().Validate(r).IsValid))
                .When(u => u.Roles.Any())
                .WithMessage("Invalid role(s)");
        }
    }
}
