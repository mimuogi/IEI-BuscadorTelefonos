using IEI_TelefonosBuscar.Connections;
using IEI_TelefonosBuscar.Data;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IEI_TelefonosBuscar.WebManagers
{
    class PCComponentesManager
    {
        private static String urlConnection = "http://pccomponentes.com";
        private static IWebDriver driver;

        private static string web = "PCComponentes";

        public static List<Telefono> Buscar(String marca, String modelo)
        {
            driver = ChromeConnection.initConnection(urlConnection);

            List<Telefono> telefonos = new List<Telefono>();

            ChromeConnection.WaitToAppear(driver, new TimeSpan(0, 0, 10), By.Name("query"));

            IWebElement cajaBusqueda = driver.FindElement(By.Name("query"));
            cajaBusqueda.SendKeys("Smartphon " + marca + " " + modelo);
            cajaBusqueda.SendKeys(Keys.Enter);

            ChromeConnection.WaitToAppear(driver, new TimeSpan(0, 0, 3), By.CssSelector("a[data-id='1116']"));

            try {

                IWebElement smartphoneCheckBox = driver.FindElement(By.CssSelector("a[data-id='1116']"));
                smartphoneCheckBox.Click();
                Thread.Sleep(3000);
            }
            catch (Exception)
            {
                driver.Quit();
                return telefonos;
            }

            ChromeConnection.WaitToAppear(driver, new TimeSpan(0, 0, 3), By.ClassName("tarjeta-articulo__elementos-basicos"));

            List<IWebElement> elementos = driver.FindElements(By.ClassName("tarjeta-articulo__elementos-basicos")).ToList();
            
            foreach (IWebElement elemento in elementos)
            {
                string nombre = elemento.FindElement(By.ClassName("tarjeta-articulo__nombre")).Text;
                string precioActual = elemento.FindElement(By.ClassName("tarjeta-articulo__precio-actual")).Text;
                string precioOriginal;
                try
                {
                     precioOriginal = elemento.FindElement(By.ClassName("tarjeta-articulo__pvp")).Text;
                }
                catch (Exception)
                {
                    precioOriginal = precioActual;
                }

                Telefono tlf = new Telefono(nombre, precioActual, precioOriginal, web);
                telefonos.Add(tlf);
               
            }

            driver.Quit();

            return telefonos;
        }
    }

}
