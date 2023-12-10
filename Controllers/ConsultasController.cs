using APIMysql.Data;
using APIMysql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIMysql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ConsultasController(APIDbContext context)
        {
            _context = context;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Consultas>> AddConsultas(Consultas consultas)
        {
            _context.Consultas.Add(consultas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedico", new { id = consultas.ConsultaId }, consultas);
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultas>>> GetConsultas()
        {
            return await _context.Consultas.ToListAsync();
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultas>> GetConsultasById(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null)
            {
                return NotFound();
            }

            return consulta;
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultas(int id, Consultas consultas)
        {
            if (id != consultas.MedicoId)
            {
                return BadRequest();
            }

            _context.Entry(consultas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaExists(id))
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
        public async Task<IActionResult> DeleteConsulta(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.ConsultaId == id);
        }
    }
}
