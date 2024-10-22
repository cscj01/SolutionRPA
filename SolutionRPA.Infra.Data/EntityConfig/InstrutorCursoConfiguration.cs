using SolutionRPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.Infra.Data.EntityConfig
{
    public class InstrutorCursoConfiguration : EntityTypeConfiguration<InstrutorCursoDTO>
    {
        public InstrutorCursoConfiguration()
        {
            HasKey(c => c.InstrutorCursoId);

            HasRequired(p => p.Instrutor)
                .WithMany()
                .HasForeignKey(c => c.InstrutorId);

            HasRequired(p => p.Curso)
                .WithMany()
                .HasForeignKey(c => c.CursoId);
        }
    }
}
