using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.WinFormsApp.Models
{
    public class InstrutorModel
    {
        public int InstrutorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Avatar { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CursoId { get; set; }
        public virtual IEnumerable<CursoModel> Curso { get; set; }
    }
}
