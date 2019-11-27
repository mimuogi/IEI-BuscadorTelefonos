using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace IEI_TelefonosBuscar.Connections
{
    class ChromeConnection
    {
        private static IWebDriver Driver { get; set; }

        public static IWebDriver initConnection(String urlConnection)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            Driver = new ChromeDriver(options);

            Driver.Navigate().GoToUrl(urlConnection);

            return Driver;
        }

        public static void WaitToAppear(IWebDriver driver, TimeSpan time, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            try
            {
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            }
            catch (Exception)
            { }
            Thread.Sleep(2000);
        }
    }
}
