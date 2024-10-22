using SolutionRPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.Infra.Data.EntityConfig
{
    public class InstrutorConfiguration : EntityTypeConfiguration<InstrutorDTO>
    {
        public InstrutorConfiguration()
        {
            HasKey(c => c.InstrutorId);

            Property(c => c.Nome)
                .HasMaxLength(200);
        }
    }
}
