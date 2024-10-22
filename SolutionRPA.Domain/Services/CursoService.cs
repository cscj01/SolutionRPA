using SolutionRPA.Domain.Entities;
using SolutionRPA.Domain.Interfaces;
using SolutionRPA.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace SolutionRPA.Domain.Services
{
    public class CursoService : GenericService<CursoDTO>, ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository) :base(cursoRepository) 
        {
              _cursoRepository = cursoRepository;
        }

        public IEnumerable<CursoDTO> BuscaPorTitulo(string titulo)
        {
            return _cursoRepository.BuscaPorTitulo(titulo);
        }
    }
}
