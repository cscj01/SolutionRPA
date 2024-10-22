using CefSharp;
using CefSharp.WinForms;
using Ninject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SolutionRPA.Application;
using SolutionRPA.Application.Interface;
using SolutionRPA.Domain.Entities;
using SolutionRPA.Infra.Data.Repositories;
using SolutionRPA.WinFormsApp.Enums;
using SolutionRPA.WinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace SolutionRPA.WinFormsApp
{
    public partial class MainForm : Form
    {
        #region Propriedades

        public ChromiumWebBrowser browser;
        public ChromeDriver _driver;
        public bool _stopBot = false;
        public bool _runBot = false;


        private readonly ICursoAppService _cursoAppService;
        private readonly IInstrutorAppService _instrutorAppService;
        private readonly IInstrutorCursoAppService _instrutorCursoAppService;
        private readonly ILogAppService _logAppService;
        //private readonly IInstrutorCursoAppService _instrutorCursoAppService;

        private readonly InstrutorRepository instrutorRepository = new InstrutorRepository();
        //private readonly InstrutorCursoRepository instrutorCursoRepository = new InstrutorCursoRepository();

        private string homePage = "https://www.alura.com.br/";
        private string searchPage = "https://www.alura.com.br/busca?query=";

        #endregion

        #region Metodos


        [Inject()]
        public MainForm(ICursoAppService cursoAppService,
            IInstrutorCursoAppService instrutorCursoAppService,
            IInstrutorAppService instrutorAppService,
            ILogAppService logAppService)
        {
            InitializeComponent();
            _cursoAppService = cursoAppService;
            _instrutorAppService = instrutorAppService;
            _logAppService = logAppService;
            _instrutorCursoAppService = instrutorCursoAppService;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            try
            {
                CheckProcessChromedriver();

                CefSettings settings = new CefSettings();
                settings.RemoteDebuggingPort = 52137;
                //settings.LocalesDirPath = AppDomain.CurrentDomain.BaseDirectory;
                Cef.Initialize(settings);
                browser = new ChromiumWebBrowser();

                if (CheckInternet())                
                    browser.LoadUrl(homePage);
                
                browser.Dock = DockStyle.Fill;
                panel3.Controls.Add(browser);
                ConnectChromeDriver();
                //Bot.ConnectChromeDriver();
            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - " +  ex.Message);
            }
        }

        private void CheckProcessChromedriver()
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            Process[] processlist = Process.GetProcessesByName("chromedriver");

            foreach (Process p in processlist)
            {
                try
                {
                    //Console.WriteLine("Process: {0} ID: {1}", p.ProcessName, p.Id);
                    p.Kill();

                }
                catch (Exception ex)
                {
                    _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - " +  ex.Message);
                }
            }
        }

        private void ConnectChromeDriver()
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            try
            {
                CheckProcessChromedriver();

                ChromeOptions options = new ChromeOptions();
                options.DebuggerAddress = "localhost:52137";

                string chromeDriverPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

                ChromeDriverService service = ChromeDriverService.CreateDefaultService(chromeDriverPath);
                service.HideCommandPromptWindow = true;

                _driver = new ChromeDriver(service, options);
            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - " + ex.Message);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            try
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    // Do some stuff
                    if (_runBot)
                    {
                        this.WindowState = FormWindowState.Maximized;
                        MessageBox.Show("Para o robô executar corretamente não pode esta com a tela minimizada ", "Atenção");
                    }
                }
            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - " + ex.Message);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            try
            {
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    if (CheckInternet())
                    {
                        if (btnExecute.Text.Contains("Executar"))
                        {
                            _logAppService.GravarLog(Enums.LogLevel.Info.ToString(), fullMethodName + " - Inicio");

                            if (WindowState != FormWindowState.Maximized)
                                this.WindowState = FormWindowState.Maximized;

                            btnExecute.Text = "Processando...[STOP]";
                            _stopBot = false;

                            Thread t = new Thread(new ThreadStart(ExecuteBot));
                            t.Start();
                        }
                        else
                        {
                            if (MessageBox.Show("Robo em execução, deseja parar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                _logAppService.GravarLog(Enums.LogLevel.Info.ToString(), "Parou");
                                btnExecute.Text = "Executar";
                                _stopBot = true;
                                _runBot = false;
                            }
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Não é possivel acessar o portal da Alura, verifique a conexão com a internet e tente novamente!", "Atenção", MessageBoxButtons.OK);
                        _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - Sem acesso ao portal da Alura" );
                    }
                }
                else
                {
                    MessageBox.Show("Informe o termo da pesquisa!", "Atenção", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - " + ex.Message);
            }
        }

        private bool CheckInternet() 
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            try
            {
                Ping myPing = new Ping();
                String host = "alura.com.br";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - " + ex.Message);
                return false;
            }
        }

        private int getLastPage()
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            int countPage = 0;

            try
            {
                var webelement = _driver.FindElement(By.XPath("//*[@class='busca-paginacao']/nav/a[5]"));

                if (webelement != null)
                {
                    countPage = int.Parse(webelement.Text);
                }

            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - " + ex.Message);
            }

            return countPage;

        }

        private string getUrlBase()
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            var urlage = "";

            try
            {
                var webelement = _driver.FindElement(By.XPath("//*[@class='busca-paginacao']/nav/a[1]"));

                if (webelement != null)
                {
                    urlage = webelement.GetAttribute("href");
                }

            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - " + ex.Message);
            }
            return urlage;
        }

        private void ExecuteBot()
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            _runBot = true;

            try
            {
                browser.Load(searchPage + HttpUtility.UrlEncode(txtSearch.Text));
                Thread.Sleep(3000);

                if (_driver == null)
                {
                    ConnectChromeDriver();
                }

                var filtro = _driver.FindElement(By.ClassName("show-filter-options"));

                if (filtro != null)
                {
                    //filtro.Click();

                    var selecionaCurso = _driver.FindElement(By.XPath("//*[@id='busca--filtros--tipos']/li[1]"));
                    if (selecionaCurso != null)
                    {
                        //ClickWebElExecuteJs(selecionaCurso);
                        selecionaCurso.Click();
                        Thread.Sleep(500);
                    }

                    var btnFiltro = _driver.FindElement(By.Id("busca--filtrar-resultados"));
                    if (btnFiltro != null)
                    {
                        btnFiltro.Click();
                    }

                }

                int countPage = 1;
                var urlBase = "";

                if (!rbtnPag.Checked)
                {
                    countPage = getLastPage();
                    urlBase = getUrlBase();
                }

                for (int i = 1; i <= countPage; i++)
                {
                    List<string> listaLink = new List<string>();
                    var listaResultado = _driver.FindElements(By.ClassName("busca-resultado"));

                    if (listaResultado != null)
                    {
                        foreach (var item in listaResultado)
                        {
                            var url = item.FindElement(By.ClassName("busca-resultado-link")).GetAttribute("href");
                            listaLink.Add(url);
                        }

                        foreach (var item in listaLink)
                        {
                            browser.Load(item);
                            Thread.Sleep(3000);

                            GetValuesResultadoBusca();
                        }
                    }

                    if (!rbtnPag.Checked)
                    {
                        if (!string.IsNullOrEmpty(urlBase))
                        {
                            if ((i + 1) < countPage)
                            {
                                var urlTratada = urlBase.Replace("pagina=1", "pagina=" + (i + 1));
                                browser.Load(urlTratada);
                                Thread.Sleep(3000);
                            }
                        }
                    }
                }

                _runBot = false;

                _logAppService.GravarLog(Enums.LogLevel.Info.ToString(), fullMethodName + " - Concluido");

                browser.LoadUrl(homePage);
                Thread.Sleep(1000);

                SetButtonExecute("Executar");

                MessageBox.Show("Consulta finalizada", "Atenção");

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("disconnected: not connected to DevTools"))
                {
                    _driver.Quit();
                    ConnectChromeDriver();
                }
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - " + ex.Message);
                _runBot = false;
                SetButtonExecute("Executar");
                MessageBox.Show("Erro: " + ex.Message, "Erro");
            }
        }

        public void ClickWebElExecuteJs(IWebElement el)
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            try
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", el);
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), fullMethodName + " - " + ex.Message);
            }
        }

        private void GetValuesResultadoBusca()
        {
            string fullMethodName = $"{MethodBase.GetCurrentMethod().ReflectedType.FullName}.{MethodBase.GetCurrentMethod().Name}";

            #region Curso

            CursoDTO cursoCadastrado = null;

            try
            {
                if (CheckWebElementExist("curso-banner-course-title", FilterBy.ClassName))
                {
                    var titulo = _driver.FindElement(By.ClassName("curso-banner-course-title")).Text;
                    var categoria = _driver.FindElement(By.ClassName("course--banner-text-category")).Text;
                    var cargaHoraria = _driver.FindElement(By.ClassName("courseInfo-card-wrapper-infos")).Text;
                    var descricaoCurso = _driver.FindElement(By.ClassName("container-list--width")).Text;

                    var c = new CursoModel
                    {
                        Titulo = titulo.Replace(":", "").Trim(),
                        Categoria = categoria.Trim(),
                        //Descricao = descricaoCurso.Substring(0, Math.Min(descricaoCurso.Length, 100)),
                        Descricao = descricaoCurso.Replace("O que você aprenderá_", "").Trim(),
                        CargaHoraria = cargaHoraria.Trim(),
                    };

                    var curso = AutoMapper.Mapper.Map<CursoDTO>(c);
                    cursoCadastrado = _cursoAppService.Add(curso);
                }
                else
                {
                    _logAppService.GravarLog(Enums.LogLevel.Info.ToString(),  $"Não localizado o titulo do curso na URL '{_driver.Url}'");
                }
            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), ex.Message);
            }

            #endregion



            #region Instrutores

            List<InstrutorDTO> instrutorCadastrado = new List<InstrutorDTO>();

            try
            {
                if (CheckWebElementExist("instructor-title--name", FilterBy.ClassName))
                {
                    var instrutorNomeLista = _driver.FindElements(By.ClassName("instructor-title--name"));
                    var instrutorDescricaoLista = _driver.FindElements(By.ClassName("instructor-description--text"));

                    for (int j = 0; j < instrutorNomeLista.Count; j++)
                    {
                        var nome = instrutorNomeLista[j].Text;
                        var descricao = instrutorDescricaoLista[j].Text;

                        if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(descricao))
                        {
                            var instrutorLocalizado = instrutorRepository.BuscaPorNomeEDescricao(nome, descricao);

                            if (instrutorLocalizado == null)
                            {
                                var ins = new InstrutorModel
                                {
                                    Nome = nome,
                                    Descricao = descricao,
                                };

                                var insDTO = AutoMapper.Mapper.Map<InstrutorDTO>(ins);
                                instrutorCadastrado.Add(instrutorRepository.Add(insDTO));
                            }
                            else
                            {
                                if (!instrutorCadastrado.Contains(instrutorLocalizado))
                                {
                                    instrutorCadastrado.Add(instrutorLocalizado);
                                }
                            }
                        }
                    }
                }
                else
                {
                    _logAppService.GravarLog(Enums.LogLevel.Info.ToString(), $"Não localizado instrutor para o curso {cursoCadastrado.Titulo}.");
                }
            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), ex.Message);
            }

            #endregion

            #region InstrutoresCursos

            try
            {
                if (cursoCadastrado != null && instrutorCadastrado.Count > 0)
                {
                    foreach (var item in instrutorCadastrado)
                    {
                        var ic = new InstrutorCursoDTO
                        {
                            CursoId = cursoCadastrado.CursoId,
                            InstrutorId = item.InstrutorId,
                        };

                        _instrutorCursoAppService.Add(ic);
                    }
                }
            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), ex.Message);
            }

            #endregion
        }

        private bool CheckWebElementExist(string webElement, FilterBy by)
        {
            try
            {
                switch (by)
                {
                    case FilterBy.ClassName:
                        _driver.FindElement(By.ClassName(webElement));
                        break;

                    case FilterBy.Id:
                        _driver.FindElement(By.Id(webElement));
                        break;

                    default:
                        break;
                }


                return true;
            }
            catch (Exception ex)
            {
                _logAppService.GravarLog(Enums.LogLevel.Erro.ToString(), ex.Message);
                return false;
            }
        }

        private void SetButtonExecute(string value)
        {
            btnExecute.BeginInvoke(new Action(() =>
            {
                btnExecute.Text = value;
            }));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckProcessChromedriver();
        }

        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                grid.DataSource = null;

                switch (comboBox1.Text)
                {
                    case "Curso":
                        var listCurso = _cursoAppService.GetAll();
                        var bindingListCurso = new BindingList<CursoDTO>(listCurso.ToList());
                        var sourceCurso = new BindingSource(bindingListCurso, null);
                        grid.DataSource = sourceCurso;

                        break;
                    case "Instrutor":
                        var listInstrutor= _instrutorAppService.GetAll();
                        var bindingListInstrutor = new BindingList<InstrutorDTO>(listInstrutor.ToList());
                        var sourceInstrutor = new BindingSource(bindingListInstrutor, null);
                        grid.DataSource = sourceInstrutor;

                        break;
                    case "Instrutor por Curso":

                        break;
                    case "Log":
                        var listLog = _logAppService.GetAll();
                        var bindingListLog = new BindingList<LogDTO>(listLog.ToList());
                        var sourceLog = new BindingSource(bindingListLog, null);
                        grid.DataSource = sourceLog;

                        break;

                    default:
                        break;
                }
            }
        }
    }
}
