using SolutionRPA.Application.Interface;
using SolutionRPA.Domain.Entities;
using SolutionRPA.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace SolutionRPA.Application
{   

    public class LogAppService : AppServiceGeneric<LogDTO>, ILogAppService
    {
        public readonly ILogService _logService;

        private static string _machineName = Environment.MachineName == null ? string.Empty : Environment.MachineName;
        private static string _userName = Environment.UserName;
        private static string _assembly = Assembly.GetEntryAssembly().GetName().Version.ToString().ToUpper().Trim();

        public LogAppService(ILogService logService) 
            : base(logService)
        {
            _logService = logService;
        }

        public bool GravarLog(string tipo, string mensagem)
        {
            try
            {
                var log = new LogDTO
                {
                    Tipo = tipo.Substring(0, 1),
                    MaquinaNome = _machineName,
                    UsuarioNome = _userName,
                    Mensagem = $"{_assembly} - {mensagem.Trim()}"
                };

                _logService.Add(log);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

    }
}
