namespace IEI_TelefonosBuscar
{
    partial class FormularioBase
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.marcaBox = new System.Windows.Forms.ComboBox();
            this.textBoxModelo = new System.Windows.Forms.TextBox();
            this.buscar_button = new System.Windows.Forms.Button();
            this.checkBoxAmazon = new System.Windows.Forms.CheckBox();
            this.checkBoxFnac = new System.Windows.Forms.CheckBox();
            this.checkBoxPCComp = new System.Windows.Forms.CheckBox();
            this.listResultView = new System.Windows.Forms.ListView();
            this.columnaProducto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaMejorPrecio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaPrecioOriginal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaWeb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaPrecioAmazon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaPrecioOriginalAmazon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaPrecioFnac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaPrecioOriginalFnac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaPrecioPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaPrecioOriginalPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // marcaBox
            // 
            this.marcaBox.FormattingEnabled = true;
            this.marcaBox.Items.AddRange(new object[] {
            "Samsung",
            "LG",
            "Sony",
            "Huawei",
            "Motorola",
            "Apple",
            "OnePlus",
            "Lenovo",
            "Xiaomi"});
            this.marcaBox.Location = new System.Drawing.Point(12, 25);
            this.marcaBox.Name = "marcaBox";
            this.marcaBox.Size = new System.Drawing.Size(169, 21);
            this.marcaBox.TabIndex = 2;
            // 
            // textBoxModelo
            // 
            this.textBoxModelo.Location = new System.Drawing.Point(187, 26);
            this.textBoxModelo.Name = "textBoxModelo";
            this.textBoxModelo.Size = new System.Drawing.Size(204, 20);
            this.textBoxModelo.TabIndex = 3;
            // 
            // buscar_button
            // 
            this.buscar_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buscar_button.Location = new System.Drawing.Point(769, 24);
            this.buscar_button.Name = "buscar_button";
            this.buscar_button.Size = new System.Drawing.Size(85, 24);
            this.buscar_button.TabIndex = 4;
            this.buscar_button.Text = "Buscar";
            this.buscar_button.UseVisualStyleBackColor = true;
            this.buscar_button.Click += new System.EventHandler(this.buscar_button_Click);
            // 
            // checkBoxAmazon
            // 
            this.checkBoxAmazon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxAmazon.AutoSize = true;
            this.checkBoxAmazon.Location = new System.Drawing.Point(516, 8);
            this.checkBoxAmazon.Name = "checkBoxAmazon";
            this.checkBoxAmazon.Size = new System.Drawing.Size(64, 17);
            this.checkBoxAmazon.TabIndex = 5;
            this.checkBoxAmazon.Text = "Amazon";
            this.checkBoxAmazon.UseVisualStyleBackColor = true;
            // 
            // checkBoxFnac
            // 
            this.checkBoxFnac.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxFnac.AutoSize = true;
            this.checkBoxFnac.Location = new System.Drawing.Point(516, 31);
            this.checkBoxFnac.Name = "checkBoxFnac";
            this.checkBoxFnac.Size = new System.Drawing.Size(50, 17);
            this.checkBoxFnac.TabIndex = 6;
            this.checkBoxFnac.Text = "Fnac";
            this.checkBoxFnac.UseVisualStyleBackColor = true;
            // 
            // checkBoxPCComp
            // 
            this.checkBoxPCComp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxPCComp.AutoSize = true;
            this.checkBoxPCComp.Location = new System.Drawing.Point(516, 54);
            this.checkBoxPCComp.Name = "checkBoxPCComp";
            this.checkBoxPCComp.Size = new System.Drawing.Size(105, 17);
            this.checkBoxPCComp.TabIndex = 7;
            this.checkBoxPCComp.Text = "PCComponentes";
            this.checkBoxPCComp.UseVisualStyleBackColor = true;
            // 
            // listResultView
            // 
            this.listResultView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listResultView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnaProducto,
            this.columnaMejorPrecio,
            this.columnaPrecioOriginal,
            this.columnaWeb,
            this.columnaPrecioAmazon,
            this.columnaPrecioOriginalAmazon,
            this.columnaPrecioFnac,
            this.columnaPrecioOriginalFnac,
            this.columnaPrecioPC,
            this.columnaPrecioOriginalPC});
            this.listResultView.HideSelection = false;
            this.listResultView.Location = new System.Drawing.Point(12, 74);
            this.listResultView.Name = "listResultView";
            this.listResultView.Size = new System.Drawing.Size(984, 381);
            this.listResultView.TabIndex = 8;
            this.listResultView.UseCompatibleStateImageBehavior = false;
            this.listResultView.View = System.Windows.Forms.View.Details;
            // 
            // columnaProducto
            // 
            this.columnaProducto.Text = "Producto";
            this.columnaProducto.Width = 175;
            // 
            // columnaMejorPrecio
            // 
            this.columnaMejorPrecio.Text = "Mejor Precio";
            this.columnaMejorPrecio.Width = 80;
            // 
            // columnaPrecioOriginal
            // 
            this.columnaPrecioOriginal.Text = "Precio Original";
            this.columnaPrecioOriginal.Width = 80;
            // 
            // columnaWeb
            // 
            this.columnaWeb.Text = "Web";
            this.columnaWeb.Width = 75;
            // 
            // columnaPrecioAmazon
            // 
            this.columnaPrecioAmazon.Text = "Amazon";
            this.columnaPrecioAmazon.Width = 80;
            // 
            // columnaPrecioOriginalAmazon
            // 
            this.columnaPrecioOriginalAmazon.Text = "Original Amazon";
            this.columnaPrecioOriginalAmazon.Width = 90;
            // 
            // columnaPrecioFnac
            // 
            this.columnaPrecioFnac.Text = "Fnac";
            this.columnaPrecioFnac.Width = 80;
            // 
            // columnaPrecioOriginalFnac
            // 
            this.columnaPrecioOriginalFnac.Text = "Original Fnac";
            this.columnaPrecioOriginalFnac.Width = 90;
            // 
            // columnaPrecioPC
            // 
            this.columnaPrecioPC.Text = "PCComponentes";
            this.columnaPrecioPC.Width = 95;
            // 
            // columnaPrecioOriginalPC
            // 
            this.columnaPrecioOriginalPC.Text = "Original PCComponentes";
            this.columnaPrecioOriginalPC.Width = 130;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(921, 26);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Limpiar";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Marca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Modelo";
            // 
            // FormularioBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 473);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.listResultView);
            this.Controls.Add(this.checkBoxPCComp);
            this.Controls.Add(this.checkBoxFnac);
            this.Controls.Add(this.checkBoxAmazon);
            this.Controls.Add(this.buscar_button);
            this.Controls.Add(this.textBoxModelo);
            this.Controls.Add(this.marcaBox);
            this.Name = "FormularioBase";
            this.Text = "Comparador Moviles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox marcaBox;
        private System.Windows.Forms.TextBox textBoxModelo;
        private System.Windows.Forms.Button buscar_button;
        private System.Windows.Forms.CheckBox checkBoxAmazon;
        private System.Windows.Forms.CheckBox checkBoxFnac;
        private System.Windows.Forms.CheckBox checkBoxPCComp;
        private System.Windows.Forms.ListView listResultView;
        private System.Windows.Forms.ColumnHeader columnaProducto;
        private System.Windows.Forms.ColumnHeader columnaMejorPrecio;
        private System.Windows.Forms.ColumnHeader columnaPrecioOriginal;
        private System.Windows.Forms.ColumnHeader columnaWeb;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnaPrecioAmazon;
        private System.Windows.Forms.ColumnHeader columnaPrecioOriginalAmazon;
        private System.Windows.Forms.ColumnHeader columnaPrecioFnac;
        private System.Windows.Forms.ColumnHeader columnaPrecioOriginalFnac;
        private System.Windows.Forms.ColumnHeader columnaPrecioPC;
        private System.Windows.Forms.ColumnHeader columnaPrecioOriginalPC;
    }
}

