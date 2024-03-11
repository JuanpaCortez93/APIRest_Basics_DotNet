using FluentValidation;
using JWT_P2.DTOs.Messages;
using JWT_P2.Services.MessageServ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private IMessageService<MessagesGetDTO, MessagesPostDTO, MessagesPutDTO> _messagesServices;
        private IValidator<MessagesPostDTO> _messagePostValidator;
        private IValidator<MessagesPutDTO> _messagePutValidator;

        public MessagesController([FromKeyedServices("messageService")]IMessageService<MessagesGetDTO, MessagesPostDTO, MessagesPutDTO> messagesServices, IValidator<MessagesPostDTO> messagePostValidator, IValidator<MessagesPutDTO> messagePutValidator)
        {
            _messagesServices = messagesServices;
            _messagePostValidator = messagePostValidator;
            _messagePutValidator = messagePutValidator;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<MessagesGetDTO>>> GetMessages()
        {
            var messagesDTO = await _messagesServices.GetMessages();
            return Ok(messagesDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<MessagesGetDTO>> GetMessageById(Guid id)
        {
            var messagesDTO = await _messagesServices.GetMessagesById(id);
            return messagesDTO != null ? Ok(messagesDTO) : NotFound();
        }

        [HttpGet("title/{title}")]
        public ActionResult<IEnumerable<MessagesGetDTO>> GetMessageByTitle(string title)
        {
            var messagesDTO = _messagesServices.GetMessagesByTitle(title);
            return messagesDTO != null ? Ok(messagesDTO) : NotFound();
        }

        [HttpGet("body/{body}")]
        public ActionResult<IEnumerable<MessagesGetDTO>> GetMessageByBody(string body)
        {
            var messagesDTO = _messagesServices.GetMessagesByTitle(body);
            return messagesDTO != null ? Ok(messagesDTO) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<MessagesGetDTO>> AddMessage(MessagesPostDTO messagesPostDTO)
        {
            var formatValidationResult = await _messagePostValidator.ValidateAsync(messagesPostDTO);
            if(!formatValidationResult.IsValid) return BadRequest(formatValidationResult.Errors);

            var messageDTO = await _messagesServices.AddMessages(messagesPostDTO);
            return CreatedAtAction(nameof(GetMessageById), new { Id = messageDTO.Id }, messageDTO);
        }

        [HttpPut]
        public async Task<ActionResult<MessagesGetDTO>> UpdateMessage(MessagesPutDTO messagesPutDTO)
        {
            var formatValidationResult = await _messagePutValidator.ValidateAsync(messagesPutDTO);
            if (!formatValidationResult.IsValid) return BadRequest(formatValidationResult.Errors);

            var messageDTO = await _messagesServices.UpdateMessages(messagesPutDTO);
            return messageDTO != null ? CreatedAtAction(nameof(GetMessageById), new { Id = messageDTO.Id }, messageDTO) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessagesGetDTO>> DeleteMessage(Guid id)
        {
            var messageDTO = await _messagesServices.DeleteMessage(id);
            return messageDTO != null ? CreatedAtAction(nameof(GetMessageById), new { Id = messageDTO.Id }, messageDTO) : NotFound();
        }


    }
}
