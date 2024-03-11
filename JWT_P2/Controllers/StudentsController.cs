using AutoMapper;
using FluentValidation;
using JWT_P2.DTOs.Students;
using JWT_P2.Models;
using JWT_P2.SchoolDatabaseContext;
using JWT_P2.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT_P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private ICommonService<StudentsGetDTO, StudentsPostDTO, StudentsPutDTO> _studentsService;
        private IValidator<StudentsPostDTO> _studentsPostValidator;
        private IValidator<StudentsPutDTO> _studentsPutValidator;

        public StudentsController([FromKeyedServices("studentsService")]ICommonService<StudentsGetDTO, StudentsPostDTO, StudentsPutDTO> studentsService,
                                   IValidator<StudentsPostDTO> studentsPostValidator,
                                   IValidator<StudentsPutDTO> studentsPutValidator
            )
        {
            _studentsService = studentsService;
            _studentsPostValidator = studentsPostValidator;
            _studentsPutValidator = studentsPutValidator;
        }


        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<StudentsGetDTO>>> GetStudents()
        {

            var studentsDTO = await _studentsService.GetElements();
            return Ok(studentsDTO);
            
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<StudentsGetDTO>> GetStudentById(Guid id)
        {
            var studentDTO = await _studentsService.GetElementById(id);
            return studentDTO != null ? Ok(studentDTO) : NotFound();
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<StudentsGetDTO>> GetStudentByName(string name)
        {
            var studentDTO = _studentsService.GetElementByName(name);
            return studentDTO != null ? Ok(studentDTO) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<StudentsGetDTO>> PostStudent(StudentsPostDTO studentsPostDTO)
        {

            var formatValidationResult = await _studentsPostValidator.ValidateAsync(studentsPostDTO);
            if(!formatValidationResult.IsValid) return BadRequest(formatValidationResult.Errors);

            var studentDTO = await _studentsService.PostElement(studentsPostDTO);
            return CreatedAtAction(nameof(GetStudentById), new { Id = studentDTO.Id }, studentDTO);

        }

        [HttpPut]
        public async Task<ActionResult<StudentsGetDTO>> PutStudents(StudentsPutDTO studentsPutDTO)
        {
            var formatValidationResult = await _studentsPutValidator.ValidateAsync(studentsPutDTO);
            if (!formatValidationResult.IsValid) return BadRequest(formatValidationResult.Errors);

            var studentDTO = await _studentsService.PutElement(studentsPutDTO);
            return studentDTO != null ? Ok(studentDTO) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentsGetDTO>> DeleteStudent(Guid id)
        {

            var studentDTO = await _studentsService.DeleteElement(id);
            return Ok(studentDTO);


        }




    }
}
