using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Services;
using api.Dto;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorService _service;

        public ProfessorsController(IProfessorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProfessorDto>> GetAll()
        {
            return Ok(_service.GetAllProfessors());
        }

        [HttpGet("{id}")]
        public ActionResult<ProfessorDto> GetById(int id)
        {
            var professor = _service.GetProfessorById(id);

            if (professor == null)
                return NotFound();
            else
                return Ok(professor);
        }

        [HttpPost]
        public ActionResult<ProfessorDto> Create([FromBody] ProfessorDto professor)
        {
            _service.AddProfessor(professor);
            return CreatedAtAction(nameof(GetById), new { id = professor.Id }, professor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProfessorDto professor)
        {
            // TODO BUG -> daca dau uncomment trb puse id urile cu mana, daca las asa se poate da update
            // TODO la entitati inexistente(adica echivalent cu POST)
            // if (id != professor.Id)
            //     return BadRequest();
            _service.UpdateProfessor(professor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteProfessor(id);
            return Ok();
        }
    }
}