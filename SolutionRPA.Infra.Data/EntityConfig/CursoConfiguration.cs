using SolutionRPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.Infra.Data.EntityConfig
{
    public class CursoConfiguration : EntityTypeConfiguration<CursoDTO>
    {
        public CursoConfiguration()
        {
            HasKey(c => c.CursoId);

            Property(c => c.CargaHoraria)
                .HasMaxLength(10);

            Property(c => c.Titulo)
                .HasMaxLength(200);

            Property(c => c.Categoria)
                .HasMaxLength(200);
        }
    }
}
