using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.Domain.Entities
{
    [Table("InstrutorCurso")]
    public class InstrutorCursoDTO
    {
        public int InstrutorCursoId { get; set; }
        public int CursoId { get; set; }
        public int InstrutorId { get; set; }
        public virtual CursoDTO Curso { get; set; }
        public virtual InstrutorDTO Instrutor { get; set; }
    }
}
