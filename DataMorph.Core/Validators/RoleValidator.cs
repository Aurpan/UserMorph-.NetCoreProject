using FluentValidation;
using UserMorph.Core.DTOs.DomainModels;

namespace UserMorph.Core.Validators
{
    public class RoleValidator: AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(r => r.RoleId)
                .IsInEnum();
        }
    }
}
