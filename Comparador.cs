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
        private static List<TelefonoComparado> listaTelefonosComparados;

        public static List<TelefonoComparado> Procesar(List<Telefono> listaTelefonos, string marca, string modelo)
        {
            listaTelefonosComparados = new List<TelefonoComparado>();
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

                Predicate<TelefonoComparado> nombreTelefonoEnLista = (TelefonoComparado t) => { return t.Nombre == telefono.Nombre; };
                Predicate<TelefonoComparado> precioOriginalEnLista = (TelefonoComparado t) => { return t.PrecioOriginalPrincipal == precioOriginal; };

                if (!listaTelefonosComparados.Exists(nombreTelefonoEnLista))
                {
                    if (!listaTelefonosComparados.Exists(precioOriginalEnLista))
                    {
                        nuevoTelefono = new TelefonoComparado(telefono.Nombre);
                    }
                    else 
                    {
                        nuevoTelefono = listaTelefonosComparados.Find(precioOriginalEnLista);
                        listaTelefonosComparados.Remove(nuevoTelefono);

                        nuevoTelefono.Nombre = marca.ToUpper() + " " + modelo.ToUpper();
                    }
                }
                else 
                {
                    nuevoTelefono = listaTelefonosComparados.Find(nombreTelefonoEnLista);
                    listaTelefonosComparados.Remove(nuevoTelefono);
                }

                if (nuevoTelefono.PrecioPrincipal.ToString().Contains("NaN") || nuevoTelefono.PrecioPrincipal > precio)
                {
                    nuevoTelefono.PrecioPrincipal = precio;
                    nuevoTelefono.PrecioOriginalPrincipal = precioOriginal;
                    nuevoTelefono.WebPrincipal = telefono.Web;
                }

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

        public static string PrecioToString(double precio) 
        {
            if (precio.ToString().Equals("NaN")) return string.Empty;
            else { return precio.ToString() + "€"; }
        }
    }
}
