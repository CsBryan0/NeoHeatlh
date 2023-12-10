using APIMysql.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMysql.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) 
        { 
            
        }
        public DbSet<Paciente>  Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consultas> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("Pacientes");

                entity.HasKey(e => e.PacienteId);
                entity.Property(e => e.PacienteId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasMaxLength(200);

            });

            modelBuilder.Entity<Consultas>(entity =>
            {
                entity.ToTable("Consultas");

                entity.HasKey(e => e.ConsultaId);
                entity.Property(e => e.ConsultaId)
                    .IsRequired()
                    .ValueGeneratedOnAdd(); 

                entity.Property(e => e.DataConsulta)
                    .IsRequired();

                entity.HasOne(c => c.Paciente)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(c => c.PacienteId)
                    .IsRequired();

                entity.HasOne(c => c.Medico)
                    .WithMany(m => m.Consultas)
                    .HasForeignKey(c => c.MedicoId)
                    .IsRequired();
            });
        }


    }
}
