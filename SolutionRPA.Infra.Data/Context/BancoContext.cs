
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using SolutionRPA.Domain.Entities;
using SolutionRPA.Infra.Data.EntityConfig;

namespace SolutionRPA.Infra.Data.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext() : base("name=BancoContext") { }

        public DbSet<CursoDTO> Cursos { get; set; }
        public DbSet<InstrutorDTO> Instrutores { get; set; }
        public DbSet<InstrutorCursoDTO> InstrutorCurso { get; set; }
        public DbSet<LogDTO> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
            .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<DateTime>()
                .Configure(p => p.HasColumnType("datetime2"));

            modelBuilder.Configurations.Add(new CursoConfiguration());
            modelBuilder.Configurations.Add(new InstrutorConfiguration());
            modelBuilder.Configurations.Add(new InstrutorCursoConfiguration());
            modelBuilder.Configurations.Add(new LogConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync();
        }

    }
}
