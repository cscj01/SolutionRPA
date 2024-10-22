using SolutionRPA.Domain.Entities;
using SolutionRPA.Domain.Interfaces;
using SolutionRPA.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace SolutionRPA.Domain.Services
{
    public class LogService : GenericService<LogDTO>, ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository) :base(logRepository) 
        {
            _logRepository = logRepository;
        }
    }
}
