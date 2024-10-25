using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionRPA.Domain.Entities
{
    [Table("TB_InstrutorCurso")]
    public class InstrutorCursoDTO
    {
        public int InstrutorCursoId { get; set; }
        public int CursoId { get; set; }
        public int InstrutorId { get; set; }
        public virtual CursoDTO Curso { get; set; }
        public virtual InstrutorDTO Instrutor { get; set; }
    }
}
