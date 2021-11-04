using Entidades.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Repositorio
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<ItemHistorico> Historico { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disciplina>().ToTable("Disciplina");
            modelBuilder.Entity<Matricula>().ToTable("Matricula");
            modelBuilder.Entity<ItemHistorico>().ToTable("Historico");
            modelBuilder.Entity<Turma>().ToTable("Turma");
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                  .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UniversityDB;Trusted_Connection=True");
                base.OnConfiguring(optionsBuilder);
            }
        }

    }
}