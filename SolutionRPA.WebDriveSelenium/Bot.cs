using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SolutionRPA.WebDriveSelenium
{
    public static class Bot
    {
        public static WebDriver ConnectChromeDriver()
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.DebuggerAddress = "localhost:52137";

                string chromeDriverPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

                ChromeDriverService service = ChromeDriverService.CreateDefaultService(chromeDriverPath);
                service.HideCommandPromptWindow = true;

                WebDriver driver = new ChromeDriver(service, options);

                return driver;

            }
            catch (Exception)
            {

            }

            return null;
        }

    }
}
