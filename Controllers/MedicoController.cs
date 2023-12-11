using APIMysql.Data;
using APIMysql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly APIDbContext _context;

        public MedicoController(APIDbContext context)
        {
            _context = context;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Medico>> AddMedico(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedico", new { id = medico.MedicoId }, medico);
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            return await _context.Medicos.ToListAsync();
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> GetMedicoById(int id)
        { 
            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
            {
                return NotFound();
            }

            return medico;
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedico(int id, Medico medico)
        {
            if (id != medico.MedicoId)
            {
                return BadRequest();
            }

            _context.Entry(medico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicoExists(int id)
        {
            return _context.Medicos.Any(e => e.MedicoId == id);
        }

    }
}
