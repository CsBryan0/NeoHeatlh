using APIMysql.Data;
using APIMysql.Models;
using Microsoft.EntityFrameworkCore;


namespace APIMysql.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly APIDbContext _context;

        public PacienteService(APIDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente> GetPacienteById(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task<IEnumerable<Paciente>> GetAllPacientes()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> AddPaciente(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<bool> UpdatePaciente(int id, Paciente paciente)
        {
            if (id != paciente.PacienteId)
            {
                return false;
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeletePaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return false;
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
