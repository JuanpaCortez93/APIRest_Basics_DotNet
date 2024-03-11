using FluentValidation;
using JWT_P2.DTOs.Parents;

namespace JWT_P2.FormatValidators.Parents
{
    public class ParentsPostFormatValidators : AbstractValidator<ParentsPostDTO>
    {
        public ParentsPostFormatValidators() 
        {
            RuleFor(parent => parent.FirstName).NotEmpty().NotNull().WithMessage("Value can not be empty or null");
            RuleFor(parent => parent.LastName).NotEmpty().NotNull().WithMessage("Value can not be empty or null");

            RuleFor(parent => parent.FirstName).Length(3,50).NotNull().WithMessage("Value need to be between 3 and 50 characters");
            RuleFor(parent => parent.LastName).Length(3,50).NotNull().WithMessage("Value need to be between 3 and 50 characters");
        }
    }
}
