using SolutionRPA.Domain.Entities;
using SolutionRPA.Domain.Interfaces;
using SolutionRPA.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace SolutionRPA.Domain.Services
{
    public class InstrutorCursoService : GenericService<InstrutorCursoDTO>, IInstrutorCursoService
    {
        private readonly IInstrutorCursoRepository _instrutorCursoRepository;

        public InstrutorCursoService(IInstrutorCursoRepository instrutorCursoRepository) :base(instrutorCursoRepository) 
        {
            _instrutorCursoRepository = instrutorCursoRepository;
        }

    }
}
