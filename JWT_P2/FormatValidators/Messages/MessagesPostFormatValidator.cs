using FluentValidation;
using JWT_P2.DTOs.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_P2.FormatValidators.Messages
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesPostFormatValidator : AbstractValidator<MessagesPostDTO>
    {
        public MessagesPostFormatValidator() 
        {
            RuleFor(message => message.Title).NotEmpty().NotNull().WithMessage("Value can not be empty or null");
            RuleFor(message => message.Body).NotEmpty().NotNull().WithMessage("Value can not be empty or null");
            RuleFor(message => message.StudentId).NotEmpty().NotNull().WithMessage("Value can not be empty or null");

            RuleFor(message => message.Title).Length(0, 250).WithMessage("Title only use max 100 characters");
            RuleFor(message => message.Body).Length(250, 1000).WithMessage("Body need to have between 250 and 1000 characters");
        }
    }
}
