using APIMysql.Models;

namespace APIMysql.Services
{
    public interface IMedicosService
    {
        Task<Medico> AddMedico(Medico medico);
        Task<IEnumerable<Medico>> GetMedicos();
        Task<Medico> GetMedicoById(int id);
        Task<Medico> UpdateMedico(int id, Medico medico);
        Task<Medico> DeleteMedico(int id);

    }
}
