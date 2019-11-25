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
            driver = ChromeConnection.initChromeConnection(urlConnection);

            IWebElement cajaBusqueda = driver.FindElement(By.Name("query"));
            cajaBusqueda.SendKeys(marca + " " + modelo);
            cajaBusqueda.Submit();

            cajaBusqueda.SendKeys(Keys.Enter);

            Thread.Sleep(3000);

            IWebElement checkBox = driver.FindElement(By.XPath("html/body/div/div[2]/div/div/div/div[2]/div/div/div[2]/div/ul/li/a"));
            checkBox.Click();

            Thread.Sleep(3000);

            List<IWebElement> elementos = driver.FindElements(By.ClassName("tarjeta-articulo__elementos-basicos")).ToList();

            List<Telefono> telefonos = new List<Telefono>();
            
            foreach (IWebElement elemento in elementos)
            {
                string nombre = elemento.FindElement(By.ClassName("tarjeta-articulo__nombre")).Text;
                string precioActual = elemento.FindElement(By.ClassName("tarjeta-articulo__precio-actual")).Text;
                string precioOriginal;
                try
                {
                     precioOriginal = elemento.FindElement(By.ClassName("tarjeta-articulo__pvp")).Text;
                }
                catch (Exception e)
                {
                     precioOriginal = String.Empty;
                }

                Telefono tlf = new Telefono(nombre, precioActual, precioOriginal, web);
                telefonos.Add(tlf);
            }

            driver.Close();

            return telefonos;
        }
    }

}
