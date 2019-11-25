using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEI_TelefonosBuscar.Connections
{
    class ChromeConnection
    {
        private static IWebDriver Driver { get; set; }

        public static IWebDriver initChromeConnection(String urlConnection)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl(urlConnection);

            return Driver;
        }
    }
}
