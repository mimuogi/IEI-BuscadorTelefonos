using IEI_TelefonosBuscar.Connections;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEI_TelefonosBuscar.WebManagers
{
    class FnacManager
    {

        private static String urlConnection = "http://fnac.es";
        private static IWebDriver driver;

        private static string web = "Fnac";

        public static List<Telefono> Buscar(String marca, String modelo)
        {
            driver = ChromeConnection.initChromeConnection(urlConnection);

            List<Telefono> telefonos = new List<Telefono>();

            //TODO

            return telefonos;
        }
    }
}
