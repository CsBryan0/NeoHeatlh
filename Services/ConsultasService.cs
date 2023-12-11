using APIMysql.Data;
using APIMysql.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIMysql.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly APIDbContext _context;

        public ConsultaService(APIDbContext context)
        {
            _context = context;
        }

        public async Task<Consultas> AddConsultas(Consultas consultas)
        {
            _context.Consultas.Add(consultas);
            await _context.SaveChangesAsync();
            return consultas;
        }

        public async Task<IEnumerable<Consultas>> GetConsultas()
        {
            return await _context.Consultas.ToListAsync();
        }

        public async Task<Consultas> GetConsultasById(int id)
        {
            return await _context.Consultas.FindAsync(id);
        }

        public async Task<bool> UpdateConsultas(int id, Consultas consultas)
        {
            if (id != consultas.ConsultaId)
            {
                return false;
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
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteConsultas(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return false;
            }

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.ConsultaId == id);
        }
    }
}
