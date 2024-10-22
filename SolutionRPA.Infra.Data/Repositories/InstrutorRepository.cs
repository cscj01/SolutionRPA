using SolutionRPA.Domain.Entities;
using SolutionRPA.Domain.Interfaces;
using SolutionRPA.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SolutionRPA.Infra.Data.Repositories
{
    public class InstrutorRepository : GenericRepository<InstrutorDTO>, IInstrutorRepository
    {
        public IEnumerable<InstrutorDTO> BuscaPorNome(string nome)
        {
            return _context.Instrutores.Where(i => i.Nome == nome);
        }

        public InstrutorDTO BuscaPorNomeEDescricao(string nome, string descricao)
        {
            return _context.Instrutores.Where(i => i.Nome == nome && i.Descricao == descricao).FirstOrDefault();
        }
    }
}
