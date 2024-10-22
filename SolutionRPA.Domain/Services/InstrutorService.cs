using SolutionRPA.Domain.Entities;
using SolutionRPA.Domain.Interfaces;
using SolutionRPA.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace SolutionRPA.Domain.Services
{
    public class InstrutorService : GenericService<InstrutorDTO>, IInstrutorService
    {
        private readonly IInstrutorRepository _instrutorRepository;

        public InstrutorService(IInstrutorRepository instrutorRepository) :base(instrutorRepository) 
        {
              _instrutorRepository = instrutorRepository;
        }

        public IEnumerable<InstrutorDTO> BuscaPorNome(string nome)
        {
            return _instrutorRepository.BuscaPorNome(nome);
        }

        public InstrutorDTO BuscaPorNomeEDescricao(string nome, string descricao)
        {
            return _instrutorRepository.BuscaPorNomeEDescricao(nome, descricao);
        }
    }
}
