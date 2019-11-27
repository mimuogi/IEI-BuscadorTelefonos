using IEI_TelefonosBuscar.Connections;
using IEI_TelefonosBuscar.Data;
using IEI_TelefonosBuscar.WebManagers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEI_TelefonosBuscar
{
    public partial class FormularioBase : Form
    {
        private IWebDriver driver;
        private List<Telefono> listaResultados = new List<Telefono>();
        private List<TelefonoComparado> listaResultadosComparados = new List<TelefonoComparado>();

        public FormularioBase()
        {
            InitializeComponent();
        }

        private void buscar_button_Click(object sender, EventArgs e)
        {
            this.ClearAll();

            string marca = marcaBox.Text;
            string modelo = textBoxModelo.Text;

            if (checkBoxAmazon.Checked && checkBoxFnac.Checked && checkBoxPCComp.Checked) Espectaculo();

            if (checkBoxPCComp.Checked) listaResultados.AddRange(PCComponentesManager.Buscar(marca, modelo));
            if (checkBoxFnac.Checked) listaResultados.AddRange(FnacManager.Buscar(marca, modelo));
            if (checkBoxAmazon.Checked) listaResultados.AddRange(AmazonManager.Buscar(marca, modelo));

            listaResultadosComparados =  Comparador.Procesar(listaResultados, marca, modelo);
            
            foreach (TelefonoComparado resultado in listaResultadosComparados)
            {
                if (pasaFiltro(resultado.Nombre))
                {
                    string[] listViewItem = 
                        { resultado.Nombre, 
                        Comparador.PrecioToString(resultado.PrecioPrincipal),
                        Comparador.PrecioToString(resultado.PrecioOriginalPrincipal),
                        resultado.WebPrincipal,
                        Comparador.PrecioToString(resultado.PrecioAmazon),
                        Comparador.PrecioToString(resultado.PrecioOriginalAmazon),
                        Comparador.PrecioToString(resultado.PrecioFnac),
                        Comparador.PrecioToString(resultado.PrecioOriginalFnac),
                        Comparador.PrecioToString(resultado.PrecioPCComponentes),
                        Comparador.PrecioToString(resultado.PrecioOriginalPCComponentes)
                        };
                    listResultView.Items.Add(new ListViewItem(listViewItem));
                }
            }

            try { driver.Quit(); } catch (Exception) { }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void ClearAll()
        {
            listaResultados.Clear();
            listResultView.Items.Clear();
        }

        private bool pasaFiltro(string nombre)
        {
            bool pasaFiltroNombre = true;
            string nombreProducto = nombre.ToLower();

            if (nombreProducto.Contains("funda")
                || nombreProducto.Contains("cover")
                || nombreProducto.Contains("protector")
                || nombreProducto.Contains("protección")
                || nombreProducto.Contains("pack")
                || nombreProducto.Contains("templado"))
            {
                pasaFiltroNombre = false;
            }

            return pasaFiltroNombre;
        }

        private void Espectaculo() 
        {
            string urlLaDonnaEMobile = "https://www.youtube.com/watch?v=xCFEk6Y8TmM";

            driver = FirefoxConnection.initConnection(urlLaDonnaEMobile);
            driver.Manage().Window.Minimize();
            try
            {
                FirefoxConnection.WaitToAppear(driver, new TimeSpan(0, 0, 2), By.CssSelector("button[class='ytp-large-play-button ytp-button']"));
                driver.FindElement(By.CssSelector("button[class='ytp-large-play-button ytp-button']")).Click();
            }
            catch 
            {
                driver.Quit();
            }

        }
    }
}
