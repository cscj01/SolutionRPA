
using SolutionRPA.Domain.Entities;
using SolutionRPA.Application.Interface;
using SolutionRPA.Domain.Interfaces.Services;

namespace SolutionRPA.Application
{

    public class InstrutorCursoAppService : AppServiceGeneric<InstrutorCursoDTO>, IInstrutorCursoAppService
    {
        public readonly IInstrutorCursoService _instrutorCursoService;

        public InstrutorCursoAppService(IInstrutorCursoService instrutorCursoService)
            : base(instrutorCursoService)
        {
            _instrutorCursoService = instrutorCursoService;
        }
    }
}
