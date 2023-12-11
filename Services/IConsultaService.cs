using APIMysql.Models;

namespace APIMysql.Services
{
    public interface IConsultaService
    {
        Task<Consultas> AddConsultas(Consultas consultas);
        Task<IEnumerable<Consultas>> GetConsultas();
        Task<Consultas> GetConsultasById(int id);
        Task<bool> UpdateConsultas(int id, Consultas consultas);
        Task<bool> DeleteConsultas(int id);
    }
}
