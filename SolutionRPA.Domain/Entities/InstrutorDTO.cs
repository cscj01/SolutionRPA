using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionRPA.Domain.Entities
{
    [Table("Instrutor")]
    public class InstrutorDTO
    {
        public int InstrutorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
