using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionRPA.Domain.Entities
{
    [Table("TB_Curso")]
    public class CursoDTO
    {
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string CargaHoraria { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
