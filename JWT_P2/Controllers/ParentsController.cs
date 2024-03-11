using FluentValidation;
using JWT_P2.DTOs.Parents;
using JWT_P2.FormatValidators.Parents;
using JWT_P2.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {

        private ICommonService<ParentsGetDTO, ParentsPostDTO, ParentsPutDTO> _parentsService;
        private IValidator<ParentsPostDTO> _parentsPostFormatValidator;
        private IValidator<ParentsPutDTO> _parentsPutFormatValidator;

        public ParentsController([FromKeyedServices("parentsService")]ICommonService<ParentsGetDTO, ParentsPostDTO, ParentsPutDTO> parentsService, IValidator<ParentsPostDTO> parentsPostFormatValidator, IValidator<ParentsPutDTO> parentsPutFormatValidator)
        {
            _parentsService = parentsService;
            _parentsPostFormatValidator = parentsPostFormatValidator;
            _parentsPutFormatValidator = parentsPutFormatValidator;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ParentsGetDTO>>> GetParents()
        {
            var parentsDTO = await _parentsService.GetElements();
            return Ok(parentsDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ParentsGetDTO>> GetParentsById(Guid id)
        {
            var parentsDTO = await _parentsService.GetElementById(id);
            return parentsDTO != null ? Ok(parentsDTO) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ParentsGetDTO>> AddParent(ParentsPostDTO parentsPostDTO)
        {

            var formatValidationResult = await _parentsPostFormatValidator.ValidateAsync(parentsPostDTO);
            if (!formatValidationResult.IsValid) return BadRequest(formatValidationResult.Errors);

            var parentsDTO = await _parentsService.PostElement(parentsPostDTO);
            return parentsPostDTO != null ? CreatedAtAction(nameof(GetParentsById), new { Id = parentsDTO.Id}, parentsDTO) : BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<ParentsGetDTO>> UpdateParent(ParentsPutDTO parentsPutDTO)
        {
            var formatValidationResult = await _parentsPutFormatValidator.ValidateAsync(parentsPutDTO);
            if (!formatValidationResult.IsValid) return BadRequest(formatValidationResult.Errors);

            var parentDTO = await _parentsService.PutElement(parentsPutDTO);
            return parentDTO != null ? CreatedAtAction(nameof(GetParentsById), new { Id = parentDTO.Id }, parentDTO) : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ParentsGetDTO>> DeleteParent(Guid id)
        {
            var parentDTO = await _parentsService.DeleteElement(id);
            return parentDTO != null ? CreatedAtAction(nameof(GetParentsById), new { Id = parentDTO.Id }, parentDTO) : BadRequest();
        }

    }
}
