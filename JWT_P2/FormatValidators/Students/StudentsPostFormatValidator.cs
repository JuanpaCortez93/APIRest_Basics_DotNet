using FluentValidation;
using JWT_P2.DTOs.Students;

namespace JWT_P2.FormatValidators.Students
{
    public class StudentsPostFormatValidator : AbstractValidator<StudentsPostDTO>
    {
        public StudentsPostFormatValidator() 
        {
            RuleFor(student => student.FirstName).NotEmpty().NotNull().WithMessage("Value can't be empty or null");
            RuleFor(student => student.LastName).NotEmpty().NotNull().WithMessage("Value can't be empty or null");
            RuleFor(student => student.Year).NotEmpty().NotNull().WithMessage("Value can't be empty or null");
            RuleFor(student => student.Group).NotEmpty().NotNull().WithMessage("Value can't be empty or null");

            RuleFor(student => student.FirstName).Length(3,50).NotNull().WithMessage("Number of characters need to be between 3 and 50");
            RuleFor(student => student.LastName).Length(3,50).NotNull().WithMessage("Number of characters need to be between 3 and 50");
            
        }
    }
}
