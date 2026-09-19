namespace TP_WinForm_equipo_e
{
    partial class PruebaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarMarcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeCategoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mensajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BotonActualizar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 121);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(949, 522);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articulosToolStripMenuItem,
            this.marcasToolStripMenuItem,
            this.categoriasToolStripMenuItem,
            this.mensajeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1024, 31);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDeToolStripMenuItem});
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(90, 27);
            this.articulosToolStripMenuItem.Text = "Articulos";
            // 
            // listadoDeToolStripMenuItem
            // 
            this.listadoDeToolStripMenuItem.Name = "listadoDeToolStripMenuItem";
            this.listadoDeToolStripMenuItem.Size = new System.Drawing.Size(253, 28);
            this.listadoDeToolStripMenuItem.Text = "Administrar Articulos";
            this.listadoDeToolStripMenuItem.Click += new System.EventHandler(this.listadoDeToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarMarcaToolStripMenuItem});
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(78, 27);
            this.marcasToolStripMenuItem.Text = "Marcas";
            // 
            // agregarMarcaToolStripMenuItem
            // 
            this.agregarMarcaToolStripMenuItem.Name = "agregarMarcaToolStripMenuItem";
            this.agregarMarcaToolStripMenuItem.Size = new System.Drawing.Size(241, 28);
            this.agregarMarcaToolStripMenuItem.Text = "Administrar Marcas";
            this.agregarMarcaToolStripMenuItem.Click += new System.EventHandler(this.agregarMarcaToolStripMenuItem_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDeCategoriasToolStripMenuItem});
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(105, 27);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            // 
            // listadoDeCategoriasToolStripMenuItem
            // 
            this.listadoDeCategoriasToolStripMenuItem.Name = "listadoDeCategoriasToolStripMenuItem";
            this.listadoDeCategoriasToolStripMenuItem.Size = new System.Drawing.Size(268, 28);
            this.listadoDeCategoriasToolStripMenuItem.Text = "Administrar Categorias";
            this.listadoDeCategoriasToolStripMenuItem.Click += new System.EventHandler(this.listadoDeCategoriasToolStripMenuItem_Click);
            // 
            // mensajeToolStripMenuItem
            // 
            this.mensajeToolStripMenuItem.Name = "mensajeToolStripMenuItem";
            this.mensajeToolStripMenuItem.Size = new System.Drawing.Size(87, 27);
            this.mensajeToolStripMenuItem.Text = "Mensaje";
            this.mensajeToolStripMenuItem.Click += new System.EventHandler(this.mensajeToolStripMenuItem_Click);
            // 
            // BotonActualizar
            // 
            this.BotonActualizar.Location = new System.Drawing.Point(16, 58);
            this.BotonActualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BotonActualizar.Name = "BotonActualizar";
            this.BotonActualizar.Size = new System.Drawing.Size(171, 55);
            this.BotonActualizar.TabIndex = 5;
            this.BotonActualizar.Text = "Actualizar";
            this.BotonActualizar.UseVisualStyleBackColor = true;
            this.BotonActualizar.Click += new System.EventHandler(this.BotonActualizar_Click);
            // 
            // PruebaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 742);
            this.Controls.Add(this.BotonActualizar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PruebaPrincipal";
            this.Text = "PruebaPrincipal";
            this.Load += new System.EventHandler(this.PruebaPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeCategoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarMarcaToolStripMenuItem;
        private System.Windows.Forms.Button BotonActualizar;
        private System.Windows.Forms.ToolStripMenuItem mensajeToolStripMenuItem;
    }
}