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

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(p => p.Matriculas)
                .WithOne(p => p.ApplicationUser)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.Admin)
                .HasDefaultValue(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}