using SolutionRPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.Infra.Data.EntityConfig
{
    public class LogConfiguration : EntityTypeConfiguration<LogDTO>
    {
        public LogConfiguration()
        {
            HasKey(c => c.LogId);

            Property(c => c.Tipo)
                .HasMaxLength(10);

            Property(c => c.UsuarioNome)
                .HasMaxLength(100);

            Property(c => c.MaquinaNome)
                .HasMaxLength(100);
        }
    }
}
