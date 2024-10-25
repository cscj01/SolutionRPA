using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionRPA.Domain.Entities
{
    [Table("TB_Log")]
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
