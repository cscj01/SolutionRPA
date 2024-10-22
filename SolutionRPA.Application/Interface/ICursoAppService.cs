using SolutionRPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.Application.Interface
{
    public interface ICursoAppService: IAppServiceGeneric<CursoDTO>
    {
        IEnumerable<CursoDTO> BuscaPorTitulo(string titulo);
    }
}
