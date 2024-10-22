using SolutionRPA.Application.Interface;
using SolutionRPA.Domain.Entities;
using SolutionRPA.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace SolutionRPA.Application
{   

    public class InstrutorAppService : AppServiceGeneric<InstrutorDTO>, IInstrutorAppService
    {
        public readonly IInstrutorService _instrutorService;

        public InstrutorAppService(IInstrutorService instrutorService) 
            : base(instrutorService)
        {
            _instrutorService = instrutorService;
        }

        public IEnumerable<InstrutorDTO> BuscaPorNome(string nome)
        {
            return _instrutorService.BuscaPorNome(nome);
        }

        public InstrutorDTO BuscaPorNomeEDescricao(string nome, string descricao)
        {
            return _instrutorService.BuscaPorNomeEDescricao(nome, descricao);
        }
    }
}
