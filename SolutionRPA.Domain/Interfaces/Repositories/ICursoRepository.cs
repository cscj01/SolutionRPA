
using SolutionRPA.Domain.Entities;
using System.Collections.Generic;

namespace SolutionRPA.Domain.Interfaces
{
    public interface ICursoRepository :IGenericRepository<CursoDTO>
    {
        IEnumerable<CursoDTO> BuscaPorTitulo(string titulo);
    }
}
