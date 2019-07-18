using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AulaManager.Models
{
    public class AulaManagerContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Grado> GradosAlumnos { get; set; }
        public DbSet<AlumnoGrado> AlumnosGrado { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }


    
    

}