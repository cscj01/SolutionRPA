using SolutionRPA.Domain.Entities;
using SolutionRPA.Domain.Interfaces;
using SolutionRPA.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace SolutionRPA.Infra.Data.Repositories
{
    public class LogRepository : GenericRepository<LogDTO>, ILogRepository
    {
        
    }
}
