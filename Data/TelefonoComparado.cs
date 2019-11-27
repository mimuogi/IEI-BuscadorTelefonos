using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEI_TelefonosBuscar.Data
{
    class TelefonoComparado : IComparable
    {
        public string Nombre { get; set; }
        public string WebPrincipal { get; set;}
        public double PrecioPrincipal { get; set;}
        public double PrecioOriginalPrincipal { get; set; }
        public double PrecioAmazon { get; set; }
        public double PrecioOriginalAmazon { get; set; }
        public double PrecioFnac { get; set; }
        public double PrecioOriginalFnac { get; set; }
        public double PrecioPCComponentes { get; set; }
        public double PrecioOriginalPCComponentes { get; set; }

        public TelefonoComparado(string nombre, string webPrincipal, double precioPrincipal, double precioOriginalPrincipal, double precioAmazon, double precioOriginalAmazon, double precioFnac, double precioOriginalFnac, double precioPC, double precioOriginalPC)
        {
            this.Nombre = nombre;
            this.WebPrincipal = webPrincipal;
            this.PrecioPrincipal = precioPrincipal;
            this.PrecioOriginalPrincipal = precioOriginalPrincipal;
            this.PrecioAmazon = precioAmazon;
            this.PrecioOriginalAmazon = precioOriginalAmazon;
            this.PrecioFnac = precioFnac;
            this.PrecioOriginalFnac = precioOriginalFnac;
            this.PrecioPCComponentes = precioPC;
            this.PrecioOriginalPCComponentes = precioOriginalPC;

        }

        public TelefonoComparado(string nombre) 
        {
            this.Nombre = nombre;
            this.WebPrincipal = string.Empty;
            this.PrecioPrincipal = Double.NaN;
            this.PrecioOriginalPrincipal = Double.NaN;
            this.PrecioAmazon = Double.NaN;
            this.PrecioOriginalAmazon = Double.NaN;
            this.PrecioFnac = Double.NaN;
            this.PrecioOriginalFnac = Double.NaN;
            this.PrecioPCComponentes = Double.NaN;
            this.PrecioOriginalPCComponentes = Double.NaN;

        }   

        private int CompareToTelefonos(TelefonoComparado otroTelefonoComparado) {

            if (this.PrecioPrincipal.CompareTo(otroTelefonoComparado.PrecioPrincipal) > 0) return 1;
            if (this.PrecioPrincipal.CompareTo(otroTelefonoComparado.PrecioPrincipal) == 0) return 0;

            return -1;

        }

        public int CompareTo(object obj)
        {
            return CompareToTelefonos((TelefonoComparado) obj);
        }
    }
}
