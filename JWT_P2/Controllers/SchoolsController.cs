using FluentValidation;
using JWT_P2.DTOs.Schools;
using JWT_P2.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace JWT_P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        
        private ICommonService<SchoolsGetDTO, SchoolsPostDTO, SchoolsPutDTO> _schoolsService;
        private IValidator<SchoolsPostDTO> _schoolPostValidator;
        private IValidator<SchoolsPutDTO> _schoolPutValidator;

        public SchoolsController
            ([FromKeyedServices("schoolsService")]ICommonService<SchoolsGetDTO, SchoolsPostDTO, SchoolsPutDTO> schoolsService, IValidator<SchoolsPostDTO> schoolPostValidator, IValidator<SchoolsPutDTO> schoolPutValidator)
        {
            _schoolsService = schoolsService;
            _schoolPostValidator = schoolPostValidator;
            _schoolPutValidator = schoolPutValidator;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SchoolsGetDTO>>> GetSchools()
        {
            var schoolsDTO = await _schoolsService.GetElements();
            return schoolsDTO != null ? Ok(schoolsDTO) : NotFound();
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<SchoolsGetDTO>> GetSchoolsById(Guid id)
        {
            var schoolsDTO = await _schoolsService.GetElementById(id);
            return Ok(schoolsDTO);
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<SchoolsGetDTO>> GetSchoolsByName(string name)
        {
            var schoolsDTO = _schoolsService.GetElementByName(name);
            return Ok(schoolsDTO);
        }

        [HttpPost]
        public async Task<ActionResult<SchoolsGetDTO>> AddSchool(SchoolsPostDTO schoolsPostDTO)
        {
            var formatValidationResult = await _schoolPostValidator.ValidateAsync(schoolsPostDTO);
            if (!formatValidationResult.IsValid) return BadRequest(formatValidationResult.Errors);

            var schoolDTO = await _schoolsService.PostElement(schoolsPostDTO);
            return CreatedAtAction(nameof(GetSchoolsById), new {Id = schoolDTO.Id}, schoolDTO);

        }

        [HttpPut]
        public async Task<ActionResult<SchoolsGetDTO>> UpdateSchool(SchoolsPutDTO schoolsPutDTO)
        {
            var formatValidationResult = await _schoolPutValidator.ValidateAsync(schoolsPutDTO);
            if (!formatValidationResult.IsValid) return BadRequest(formatValidationResult.Errors);

            var schoolDTO = await _schoolsService.PutElement(schoolsPutDTO);
            return schoolDTO != null ? CreatedAtAction(nameof(GetSchoolsById), new { Id = schoolDTO.Id }, schoolDTO) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SchoolsGetDTO>> DeleteSchool(Guid id)
        {
            var schoolDTO = await _schoolsService.DeleteElement(id);
            return schoolDTO != null ? CreatedAtAction(nameof(GetSchoolsById), new { Id = schoolDTO.Id }, schoolDTO) : NotFound();
        }

    }
}
