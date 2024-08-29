using ApiWebCMSR.models;
using Microsoft.EntityFrameworkCore;
using ProyectoCMSR.Server.models;

namespace ProyectoCMSR.Server.Data
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto> opt) : base(opt)
        {

        }
        public DbSet<Especialidad> Especialidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Seeding de datos iniciales (opcional)
            modelBuilder.Entity<Especialidad>().HasData(
                new Especialidad { Id = 1, Nombre = "Anestesia General" },
                new Especialidad { Id = 2, Nombre = "Anestesia Pediátrica" },
                new Especialidad { Id = 3, Nombre = "Cardiología/Hemodinamista" },
                new Especialidad { Id = 4, Nombre = "Cardiología Pediátrica" },
                new Especialidad { Id = 5, Nombre = "Cirugía Vascular" },
                new Especialidad { Id = 6, Nombre = "Cirugía General" },
                new Especialidad { Id = 7, Nombre = "Cirugía Pediátrica" },
                new Especialidad { Id = 8, Nombre = "Cirugía Maxilofacial" },
                new Especialidad { Id = 9, Nombre = "Dermatología" },
                new Especialidad { Id = 10, Nombre = "Cirugía Facial" },
                new Especialidad { Id = 11, Nombre = "Diabetología" },
                new Especialidad { Id = 12, Nombre = "Endocrinología" },
                new Especialidad { Id = 13, Nombre = "Gastroenterología Pediátrico" },
                new Especialidad { Id = 14, Nombre = "Gastroenterología" },
                new Especialidad { Id = 15, Nombre = "Geriatría" },
                new Especialidad { Id = 16, Nombre = "Gineco-Obstetricia" },
                new Especialidad { Id = 17, Nombre = "Intensivista" },
                new Especialidad { Id = 18, Nombre = "Medicina Interna" },
                new Especialidad { Id = 19, Nombre = "Medicina Familiar" },
                new Especialidad { Id = 20, Nombre = "Neonatología" },
                new Especialidad { Id = 21, Nombre = "Neumología" },
                new Especialidad { Id = 22, Nombre = "Neurología" },
                new Especialidad { Id = 23, Nombre = "Neurocirugía" },
                new Especialidad { Id = 24, Nombre = "Ortopedia" },
                new Especialidad { Id = 25, Nombre = "Traumatología" },
                new Especialidad { Id = 26, Nombre = "Ortopedia Pediátrica" },
                new Especialidad { Id = 27, Nombre = "Otorrinolaringología" },
                new Especialidad { Id = 28, Nombre = "Oftalmología" },
                new Especialidad { Id = 29, Nombre = "Pediatría" },
                new Especialidad { Id = 30, Nombre = "Psiquiatría" },
                new Especialidad { Id = 31, Nombre = "Psicología" },
                new Especialidad { Id = 32, Nombre = "Urología" },
                new Especialidad { Id = 33, Nombre = "Nefrología" }
            );
        }

        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Articulos> Articulos { get; set; }

    }
}
