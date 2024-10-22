using System;
using System.Windows.Forms;
using Ninject;
using SolutionRPA.Domain.Entities;
using SolutionRPA.WinFormsApp.Models;
using SolutionRPA.WinFormsApp.Module;

namespace SolutionRPA.WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitializeAutoMapper();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);


            FormResolve.Wire(MainFormModule.Create());
            System.Windows.Forms.Application.Run(FormResolve.Resolve<MainForm>());

            //var kernel = new StandardKernel(new ModuleRegisteringICountRepository());
            //var form = kernel.Get<MainForm>();
            //Application.Run(form);
        }

        public static void InitializeAutoMapper()
        {
            AutoMapper.Mapper.Initialize(Load());
        }

        public static Action<AutoMapper.IMapperConfigurationExpression> Load()
        {
            return _ =>
            {
                _.CreateMap<CursoModel, CursoDTO>();
                _.CreateMap<InstrutorModel, InstrutorDTO>();
            };
        }
    }
}
