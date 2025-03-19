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
            try
            {
                // Validăm dacă ID-ul din URL coincide cu ID-ul din DTO (dacă este furnizat)
                if (professor.Id != 0 && professor.Id != id)
                {
                    return BadRequest("ID-ul din URL nu coincide cu ID-ul din corpul cererii");
                }
        
                // Setăm ID-ul din URL pe obiectul DTO
                professor.Id = id;
        
                // Încercăm să actualizăm profesorul
                _service.UpdateProfessor(professor);
        
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Professor with ID {id} not found");
            }
            catch (Exception ex)
            {
                // Log-uiește excepția
                return StatusCode(500, "A apărut o eroare internă. Vă rugăm să încercați din nou.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteProfessor(id);
            return Ok();
        }
    }
}