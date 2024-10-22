using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.Domain.Entities
{
    [Table("Log")]
    public class LogDTO
    {
        public int LogId { get; set; }
        public string Tipo { get; set; }
        public string UsuarioNome { get; set; }
        public string MaquinaNome { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
