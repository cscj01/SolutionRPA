﻿using SolutionRPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.Domain.Interfaces.Services
{
    public interface ICursoService: IGenericService<CursoDTO>
    {
        IEnumerable<CursoDTO> BuscaPorTitulo(string titulo);
    }
}
