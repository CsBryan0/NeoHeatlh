namespace APIMysql.Models
{
    public class Consultas
    {

        public int ConsultaId { get; set; }
        public DateTime DataConsulta { get; set; }


        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }


        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
    }
}
