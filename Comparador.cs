using IEI_TelefonosBuscar.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEI_TelefonosBuscar
{
    class Comparador
    {
       public static List<TelefonoComparado> Procesar(List<Telefono> listaTelefonos)
        {
            List<TelefonoComparado> listaTelefonosComparados = new List<TelefonoComparado>();
            double precio;
            double precioOriginal;
            string precioString;
            string precioOriginalString;

            foreach (Telefono telefono in listaTelefonos) 
            {
                precioString = telefono.Precio;
                precioOriginalString = telefono.PrecioOriginal;

                precioString = TransformarParaUSDouble(precioString);
                precioOriginalString = TransformarParaUSDouble(precioOriginalString);

                CultureInfo usCulture = new CultureInfo("en-US");
                
                precio = double.Parse(precioString, usCulture.NumberFormat);
                precioOriginal = double.Parse(precioOriginalString, usCulture.NumberFormat);

                TelefonoComparado nuevoTelefono = new TelefonoComparado(telefono.Nombre);

                nuevoTelefono.PrecioPrincipal = precio;
                nuevoTelefono.PrecioOriginalPrincipal = precioOriginal;
                nuevoTelefono.WebPrincipal = telefono.Web;

                switch (telefono.Web)
                {
                    case "Amazon":
                        nuevoTelefono.PrecioAmazon = precio;
                        nuevoTelefono.PrecioOriginalAmazon = precioOriginal;
                        break;

                    case "Fnac":
                        nuevoTelefono.PrecioFnac = precio;
                        nuevoTelefono.PrecioOriginalFnac = precioOriginal;

                        break;

                    case "PCComponentes":
                        nuevoTelefono.PrecioPCComponentes = precio;
                        nuevoTelefono.PrecioOriginalPCComponentes = precioOriginal;

                        break;
                }

                listaTelefonosComparados.Add(nuevoTelefono);
            }

            listaTelefonosComparados.Sort();
            return listaTelefonosComparados;
        }

        private static string TransformarParaUSDouble(string precioCompleto)
        {
            string resultado = precioCompleto;

            resultado = resultado.Replace(" ", string.Empty);
            resultado = resultado.Replace(".", string.Empty);
            resultado = resultado.Replace("€", string.Empty);
            resultado = resultado.Replace(",", ".");

            return resultado;
        }
    }
}
