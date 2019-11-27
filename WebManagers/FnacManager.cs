using IEI_TelefonosBuscar.Connections;
using IEI_TelefonosBuscar.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IEI_TelefonosBuscar.WebManagers
{
    class FnacManager
    {

        private static String urlConnection = "http://fnac.es";
        private static IWebDriver driver;

        private static string web = "Fnac";

        public static List<Telefono> Buscar(String marca, String modelo)
        {
            driver = ChromeConnection.initConnection(urlConnection);

            List<Telefono> telefonos = new List<Telefono>();

            ChromeConnection.WaitToAppear(driver, new TimeSpan(0, 0, 10), By.Name("Search"));

            IWebElement cajaBusqueda = driver.FindElement(By.Name("Search"));
            cajaBusqueda.SendKeys(marca + " " + modelo);
            cajaBusqueda.Submit();

            try
            {
                ChromeConnection.WaitToAppear(driver, new TimeSpan(0, 0, 10), By.CssSelector("span[data-category='8!1,8020!2']"));
                IWebElement smartphoneCheck = driver.FindElement(By.CssSelector("span[data-category='8!1,8020!2']"));
                smartphoneCheck.Click();
            }
            catch (Exception) 
            { 
                driver.Quit();
                return telefonos;
            }

            ChromeConnection.WaitToAppear(driver, new TimeSpan(0, 0, 10), By.ClassName("Article-item"));

            List<IWebElement> elementos = driver.FindElements(By.ClassName("Article-item")).ToList();

            foreach(IWebElement elemento in elementos)
            {
                string nombre = elemento.FindElement(By.ClassName("Article-title")).Text;
                string precioActual = string.Empty;
                string precioOriginal = string.Empty;

                try
                {
                    precioActual = elemento.FindElement(By.ClassName("price'")).Text;
                }
                catch (Exception) {
                    try
                    {
                        precioActual = elemento.FindElement(By.ClassName("userPrice")).Text;
                    }
                    catch (Exception) 
                    {

                    }
                }
                try
                {
                    precioActual = elemento.FindElement(By.ClassName("oldPrice")).Text;
                }
                catch (Exception)
                {
                    precioOriginal = precioActual;
                }

                if (precioOriginal.Equals(string.Empty)) precioOriginal = precioActual;
                
                    if (pasaFiltroNombre(nombre, marca, modelo)) 
                { 
                Telefono tlf = new Telefono(nombre, precioActual, precioOriginal, web);
                telefonos.Add(tlf);
                }
            }

            driver.Quit();

            return telefonos;
        }

        private static bool pasaFiltroNombre(string nombre, string marca, string modelo)
        {
            bool pasaFiltro = true;
            string nombreProducto = nombre.ToLower();
            string nombreMarca = marca.ToLower();
            string nombreModelo = modelo.ToLower();

            if (!nombreProducto.Contains(nombreMarca) || !nombreProducto.Contains(nombreModelo))
            {
                pasaFiltro = false;
            }

            return pasaFiltro;
        }
    }
}
