using SolutionRPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.Application.Interface
{
    public interface IInstrutorAppService : IAppServiceGeneric<InstrutorDTO>
    {
        IEnumerable<InstrutorDTO> BuscaPorNome(string nome);

        InstrutorDTO BuscaPorNomeEDescricao(string nome, string descricao);
    }
}
