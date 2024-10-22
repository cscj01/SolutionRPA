using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.Domain.Entities
{
    [Table("Curso")]
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
