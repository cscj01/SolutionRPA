using SolutionRPA.Domain.Entities;
using System.Collections.Generic;

namespace SolutionRPA.Domain.Interfaces
{
    
    public interface IInstrutorRepository : IGenericRepository<InstrutorDTO>
    {
        IEnumerable<InstrutorDTO> BuscaPorNome(string nome);
        InstrutorDTO BuscaPorNomeEDescricao(string nome, string descricao);


    }
}
