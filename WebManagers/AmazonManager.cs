using IEI_TelefonosBuscar.Connections;
using IEI_TelefonosBuscar.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            IWebElement cajaBusqueda = driver.FindElement(By.Id("twotabsearchtextbox"));
            cajaBusqueda.SendKeys(marca + " " + modelo);
            cajaBusqueda.Submit();

            Thread.Sleep(3000);

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
                        catch (Exception e)
                        {
                            precioOriginal = precioActual;
                        }
                    }
                    catch (Exception ex)
                    {
                        precioActual = elemento.FindElement(By.CssSelector("span[class='a-color-base']")).Text;

                        precioOriginal = precioActual;
                    }

                if (!esPatrocinado(elemento))
                {
                    Telefono tlf = new Telefono(nombre, precioActual, precioOriginal, web);
                    telefonos.Add(tlf);
                }

            }

            driver.Quit();

            return telefonos;
        }

        private static bool esPatrocinado(IWebElement elemento) {

            bool patrocinado = false;
            try { patrocinado = elemento.FindElement(By.CssSelector("div[class='a-row a-spacing-micro']")).Displayed; }
            catch (Exception e)
            {
                patrocinado = false;
            }

            return patrocinado;
        }
    }
}
