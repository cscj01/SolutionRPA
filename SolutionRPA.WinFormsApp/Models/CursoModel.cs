using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.WinFormsApp.Models
{
    public class CursoModel
    {
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string CargaHoraria { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual InstrutorModel Instrutor { get; set; }
    }
}
