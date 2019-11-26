using IEI_TelefonosBuscar.Connections;
using IEI_TelefonosBuscar.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IEI_TelefonosBuscar.WebManagers
{
    class AmazonManager
    {

        private static String urlConnection = "https://www.amazon.es/s?__mk_es_ES=%C3%85M%C3%85%C5%BD%C3%95%C3%91&k=&ref=nb_sb_noss&rh=n%3A934197031&url=node%3D934197031";
         private static IWebDriver driver;

        private static string web = "Amazon";

        public static List<Telefono> Buscar(String marca, String modelo)
        {
            driver = FirefoxConnection.initConnection(urlConnection);

            List<Telefono> telefonos = new List<Telefono>();

            FirefoxConnection.WaitToAppear(driver, new TimeSpan(0, 0, 10), By.Id("twotabsearchtextbox"));

            IWebElement cajaBusqueda = driver.FindElement(By.Id("twotabsearchtextbox"));
            cajaBusqueda.SendKeys(marca + " " + modelo);
            cajaBusqueda.Submit();


            FirefoxConnection.WaitToAppear(driver, new TimeSpan(0, 0, 10), By.XPath("//*[contains(@class, 's-result-item')]"));

            List<IWebElement> elementos = driver.FindElements(By.XPath("//*[contains(@class, 's-result-item')]")).ToList();

            foreach (IWebElement elemento in elementos)
            {
                string nombre = elemento.FindElement(By.CssSelector("span.a-text-normal")).Text;
                string precioActual = string.Empty;
                string precioOriginal = string.Empty;
                    try
                    {
                        precioActual = elemento.FindElement(By.CssSelector("span[class='a-price']")).Text;
                        try
                        {
                            precioOriginal = elemento.FindElement(By.CssSelector("span[class='a-price a-text-price']")).Text;
                        }
                        catch (Exception)
                        {
                            precioOriginal = precioActual;
                        }
                    }
                    catch (Exception)
                    {
                        precioActual = elemento.FindElement(By.CssSelector("span[class='a-color-base']")).Text;

                        precioOriginal = precioActual;
                    }

                if (!esPatrocinado(elemento) && pasaFiltroNombre(nombre, marca, modelo))
                {
                    Telefono tlf = new Telefono(nombre, precioActual, precioOriginal, web);
                    telefonos.Add(tlf);
                }

            }

            driver.Quit();

            return telefonos;
        }

        private static bool esPatrocinado(IWebElement elemento) {

            bool patrocinado;
            try { patrocinado = elemento.FindElement(By.CssSelector("div[class='a-row a-spacing-micro']")).Displayed; }
            catch (Exception)
            {
                patrocinado = false;
            }

            return patrocinado;
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
