using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEI_TelefonosBuscar
{
    class Telefono
    {
        public String Nombre { get; set;}
        public String Precio { get; set; }
        public String PrecioOriginal { get; set; }
        public String Web { get; set; }

        public Telefono(String nombre, String precio, String precioOriginal, String web)
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.PrecioOriginal = precioOriginal;
            this.Web = web;
        }

        public String toString()
        {
            return Nombre + " " + Precio + " " + PrecioOriginal + " " + Web;
        }
    }
}
