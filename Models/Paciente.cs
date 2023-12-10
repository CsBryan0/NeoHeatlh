using System.ComponentModel.DataAnnotations;

namespace APIMysql.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string? NomePaciente { get; set; }

        public ICollection<Consultas> Consultas { get; set; }

        public Paciente() 
        {
            Consultas = new List<Consultas>();
        }
    }
}
