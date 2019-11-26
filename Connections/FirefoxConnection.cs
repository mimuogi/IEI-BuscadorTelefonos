using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEI_TelefonosBuscar.Connections
{
    class FirefoxConnection
    {
        private static IWebDriver Driver { get; set; }

        public static IWebDriver initConnection(String urlConnection)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("--start-maximized");

            Driver = new FirefoxDriver();

            Driver.Navigate().GoToUrl(urlConnection);

            return Driver;
        }

    }
}
