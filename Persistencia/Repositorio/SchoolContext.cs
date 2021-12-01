using Entidades.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Repositorio
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolContext() : base()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<ItemHistorico> Historico { get; set; }

        public DbSet<Turma> Turma { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            modelBuilder.Entity<Disciplina>().ToTable("Disciplina");
            modelBuilder.Entity<ItemHistorico>().ToTable("Historico");
            modelBuilder.Entity<Turma>().ToTable("Turma");
            modelBuilder.Entity<Matricula>().ToTable("Matricula");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                  .UseSqlServer(@"Server=W10781D0B3\SQLEXPRESS;Database=UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true");
                base.OnConfiguring(optionsBuilder);
            }
        }

    }
}