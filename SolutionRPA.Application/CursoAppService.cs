using SolutionRPA.Application.Interface;
using SolutionRPA.Domain.Entities;
using SolutionRPA.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace SolutionRPA.Application
{
    public class CursoAppService : AppServiceGeneric<CursoDTO>, ICursoAppService
    {
        public readonly ICursoService _cursoService;

        public CursoAppService(ICursoService cursoService) 
            : base(cursoService)
        {
            _cursoService = cursoService;
        }

        public IEnumerable<CursoDTO> BuscaPorTitulo(string titulo)
        {
            return _cursoService.BuscaPorTitulo(titulo);
        }
    }
}
