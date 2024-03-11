using FluentValidation;
using JWT_P2.DTOs.Schools;

namespace JWT_P2.FormatValidators.Schools
{
    public class SchoolsPutFormatValidator : AbstractValidator<SchoolsPutDTO>
    {
        public SchoolsPutFormatValidator()
        {
            RuleFor(school => school.Name).NotEmpty().NotNull().WithMessage("Values can't be empty or null");
            RuleFor(school => school.Name).Length(0, 50).WithMessage("Values can't be with more of 50 characteres");
        }
    }
}
