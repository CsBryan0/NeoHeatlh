using APIMysql.Models;

namespace APIMysql.Services
{
    public interface IPacienteService
    {
        Task<Paciente> GetPacienteById(int id);
        Task<IEnumerable<Paciente>> GetAllPacientes ();
        Task<Paciente> AddPaciente(Paciente paciente);
        Task<bool> UpdatePaciente (int id, Paciente paciente);
        Task<bool> DeletePaciente (int id);
    }
}
