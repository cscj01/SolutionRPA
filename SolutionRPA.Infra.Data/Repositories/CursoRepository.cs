using SolutionRPA.Domain.Entities;
using SolutionRPA.Domain.Interfaces;
using SolutionRPA.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SolutionRPA.Infra.Data.Repositories
{
    public class CursoRepository : GenericRepository<CursoDTO>, ICursoRepository
    {
        public IEnumerable<CursoDTO> BuscaPorTitulo(string titulo)
        {
            return _context.Cursos.Where(i => i.Titulo == titulo);
        }
    }
}
