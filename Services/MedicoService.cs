using APIMysql.Data;
using APIMysql.Models;
using Microsoft.EntityFrameworkCore;


namespace APIMysql.Services
{
    public class MedicoService : IMedicosService
    {
        private readonly APIDbContext _context;

        public MedicoService(APIDbContext context)
        {
            _context = context;
        }

        public async Task<Medico> AddMedico(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<Medico> DeleteMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                return null; // ou outra lógica de tratamento
            }

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<Medico> GetMedicoById(int id)
        {
            return await _context.Medicos.FindAsync(id);
        }

        public async Task<IEnumerable<Medico>> GetMedicos()
        {
            return await _context.Medicos.ToListAsync();
        }

        public async Task<Medico> UpdateMedico(int id, Medico medico)
        {
            if (id != medico.MedicoId)
            {
                return null; // ou outra lógica de tratamento
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
                    return null; // ou outra lógica de tratamento
                }
                else
                {
                    throw;
                }
            }

            return medico;
        }

        private bool MedicoExists(int id)
        {
            return _context.Medicos.Any(e => e.MedicoId == id);
        }
    }
}
