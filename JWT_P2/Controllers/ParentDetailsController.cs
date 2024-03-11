using JWT_P2.DTOs.ParentDetails;
using JWT_P2.Services.ParentDetailsServ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_P2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentDetailsController : ControllerBase
    {

        private readonly IParentDetailsService<ParentDetailsGetDTO, ParentDetailsPostDTO, ParentDetailsPutDTO> _parentDetailsService;

        public ParentDetailsController(IParentDetailsService<ParentDetailsGetDTO, ParentDetailsPostDTO, ParentDetailsPutDTO> parentDetailsService)
        {
            _parentDetailsService = parentDetailsService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ParentDetailsGetDTO>>> GetAllParentDetails()
        {
            var parentDetailsDTO = await _parentDetailsService.GetParentDetails();
            return Ok(parentDetailsDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ParentDetailsGetDTO>> GetParentDetailsById(Guid id)
        {
            var parentDetailDTO = await _parentDetailsService.GetParentDetailsById(id);
            return parentDetailDTO != null ? Ok(parentDetailDTO) : NotFound();
        }

        [HttpGet("parentid/{id}")]
        public async Task<ActionResult<IEnumerable<ParentDetailsGetDTO>>> GetParentDetailsByParentId(Guid id)
        {
            var parentDetailDTO = await _parentDetailsService.GetParentDetailsByParentId(id);
            return parentDetailDTO != null ? Ok(parentDetailDTO) : NotFound();
        }

        [HttpGet("studentid/{id}")]
        public async Task<ActionResult<IEnumerable<ParentDetailsGetDTO>>> GetParentDetailsByStudenttId(Guid id)
        {
            var parentDetailDTO = await _parentDetailsService.GetParentDetailsByStudentId(id);
            return parentDetailDTO != null ? Ok(parentDetailDTO) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ParentDetailsGetDTO>> AddParentDetails(ParentDetailsPostDTO parentDetailsPostDTO)
        {
            var parentDetailDTO = await _parentDetailsService.AddParentDetails(parentDetailsPostDTO);
            return Ok(parentDetailDTO);
        }

        [HttpPut]
        public async Task<ActionResult<ParentDetailsGetDTO>> UpdateParentDetails(ParentDetailsPutDTO parentDetailsPutDTO)
        {
            var parentDetailDTO = await _parentDetailsService.UpdateParentDetails(parentDetailsPutDTO);
            return parentDetailDTO != null ? Ok(parentDetailDTO) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ParentDetailsGetDTO>> DeleteParentDetails(Guid id)
        {
            var parentDetailDTO = await _parentDetailsService.DeleteParentDetails(id);
            return parentDetailDTO != null ? Ok(parentDetailDTO) : NotFound();
        }

    }
}
