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

            if (checkBoxAmazon.Checked) listaResultados.AddRange(AmazonManager.Buscar(marca, modelo));
            if (checkBoxFnac.Checked) listaResultados.AddRange(FnacManager.Buscar(marca, modelo));
            if (checkBoxPCComp.Checked) listaResultados.AddRange(PCComponentesManager.Buscar(marca, modelo));

            listaResultadosComparados =  Comparador.Procesar(listaResultados);

            foreach (TelefonoComparado resultado in listaResultadosComparados)
            {
                if (pasaFiltro(resultado.Nombre))
                {
                    string[] listViewItem = { resultado.Nombre, resultado.PrecioPrincipal.ToString() + "€", resultado.PrecioOriginalPrincipal.ToString() + "€", resultado.WebPrincipal };
                    listResultView.Items.Add(new ListViewItem(listViewItem));
                }
            }

            driver.Quit();
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
            driver.FindElement(By.CssSelector("button[class='ytp-large-play-button ytp-button']")).Click();

        }
    }
}
