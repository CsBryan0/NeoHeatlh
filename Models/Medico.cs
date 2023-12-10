namespace APIMysql.Models
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public string? NomeMedico { get; set; }
        public string? Especialidade { get; set; }

        public ICollection<Consultas> Consultas { get; set; }


    }
}
