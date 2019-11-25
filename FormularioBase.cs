using IEI_TelefonosBuscar.WebManagers;
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
        private List<Telefono> listaResultados = new List<Telefono>();
        public FormularioBase()
        {
            InitializeComponent();
        }

        private void buscar_button_Click(object sender, EventArgs e)
        {
            this.ClearAll();

            string marca = marcaBox.Text;
            string modelo = textBoxModelo.Text;

            if(checkBoxAmazon.Checked) listaResultados.AddRange(AmazonManager.Buscar(marca, modelo));
            if(checkBoxFnac.Checked) listaResultados.AddRange(FnacManager.Buscar(marca, modelo));
            if(checkBoxPCComp.Checked) listaResultados.AddRange(PCComponentesManager.Buscar(marca, modelo));
            
            foreach(Telefono resultado in listaResultados)
            {
                string[] listViewItem = { resultado.Nombre, resultado.Precio, resultado.PrecioOriginal, resultado.Web };
                listResultView.Items.Add(new ListViewItem(listViewItem));
            }
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
    }
}
