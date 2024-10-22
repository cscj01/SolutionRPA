using Ninject.Modules;
using SolutionRPA.Application;
using SolutionRPA.Application.Interface;
using SolutionRPA.Domain.Interfaces;
using SolutionRPA.Domain.Interfaces.Services;
using SolutionRPA.Domain.Services;
using SolutionRPA.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.WinFormsApp.Module
{
    public class MainFormModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAppServiceGeneric<>)).To(typeof(AppServiceGeneric<>));
            Bind<ICursoAppService>().To<CursoAppService>();
            Bind<IInstrutorAppService>().To<InstrutorAppService>();
            Bind<IInstrutorCursoAppService>().To<InstrutorCursoAppService>();
            Bind<ILogAppService>().To<LogAppService>();


            Bind(typeof(IGenericService<>)).To(typeof(GenericService<>));
            Bind<ICursoService>().To<CursoService>();
            Bind<IInstrutorService>().To<InstrutorService>();
            Bind<IInstrutorCursoService>().To<InstrutorCursoService>();
            Bind<ILogService>().To<LogService>();


            Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            Bind<ICursoRepository>().To<CursoRepository>();
            Bind<IInstrutorRepository>().To<InstrutorRepository>();
            Bind<IInstrutorCursoRepository>().To<InstrutorCursoRepository>();
            Bind<ILogRepository>().To<LogRepository>();
        }

        public static MainFormModule Create()
        {
            return new MainFormModule();
        }
    }
}
