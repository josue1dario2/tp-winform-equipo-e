namespace TP_WinForm_equipo_e
{
    partial class AdministrarCategorias
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
            this.BotonEliminar = new System.Windows.Forms.Button();
            this.BotonModificar = new System.Windows.Forms.Button();
            this.textBoxModificarEliminarCategoria = new System.Windows.Forms.TextBox();
            this.botonAgregarCategoria = new System.Windows.Forms.Button();
            this.textboxNombreCategoria = new System.Windows.Forms.TextBox();
            this.lbAgregar = new System.Windows.Forms.Label();
            this.lbTodasLasCategorias = new System.Windows.Forms.Label();
            this.lbCategoriaDetalles = new System.Windows.Forms.Label();
            this.dvgListadoCategorias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgListadoCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // BotonEliminar
            // 
            this.BotonEliminar.Location = new System.Drawing.Point(444, 471);
            this.BotonEliminar.Name = "BotonEliminar";
            this.BotonEliminar.Size = new System.Drawing.Size(88, 30);
            this.BotonEliminar.TabIndex = 18;
            this.BotonEliminar.Text = "Eliminar";
            this.BotonEliminar.UseVisualStyleBackColor = true;
            this.BotonEliminar.Click += new System.EventHandler(this.BotonEliminar_Click);
            // 
            // BotonModificar
            // 
            this.BotonModificar.Location = new System.Drawing.Point(337, 471);
            this.BotonModificar.Name = "BotonModificar";
            this.BotonModificar.Size = new System.Drawing.Size(88, 30);
            this.BotonModificar.TabIndex = 17;
            this.BotonModificar.Text = "Modificar";
            this.BotonModificar.UseVisualStyleBackColor = true;
            this.BotonModificar.Click += new System.EventHandler(this.BotonModificar_Click);
            // 
            // textBoxModificarEliminarCategoria
            // 
            this.textBoxModificarEliminarCategoria.Location = new System.Drawing.Point(391, 442);
            this.textBoxModificarEliminarCategoria.Name = "textBoxModificarEliminarCategoria";
            this.textBoxModificarEliminarCategoria.Size = new System.Drawing.Size(115, 20);
            this.textBoxModificarEliminarCategoria.TabIndex = 16;
            // 
            // botonAgregarCategoria
            // 
            this.botonAgregarCategoria.Location = new System.Drawing.Point(533, 10);
            this.botonAgregarCategoria.Name = "botonAgregarCategoria";
            this.botonAgregarCategoria.Size = new System.Drawing.Size(88, 30);
            this.botonAgregarCategoria.TabIndex = 15;
            this.botonAgregarCategoria.Text = "Agregar";
            this.botonAgregarCategoria.UseVisualStyleBackColor = true;
            this.botonAgregarCategoria.Click += new System.EventHandler(this.botonAgregarCategoria_Click);
            // 
            // textboxNombreCategoria
            // 
            this.textboxNombreCategoria.Location = new System.Drawing.Point(391, 16);
            this.textboxNombreCategoria.Name = "textboxNombreCategoria";
            this.textboxNombreCategoria.Size = new System.Drawing.Size(115, 20);
            this.textboxNombreCategoria.TabIndex = 14;
            // 
            // lbAgregar
            // 
            this.lbAgregar.AutoSize = true;
            this.lbAgregar.Location = new System.Drawing.Point(291, 19);
            this.lbAgregar.Name = "lbAgregar";
            this.lbAgregar.Size = new System.Drawing.Size(98, 13);
            this.lbAgregar.TabIndex = 13;
            this.lbAgregar.Text = "Agregar Categoria: ";
            // 
            // lbTodasLasCategorias
            // 
            this.lbTodasLasCategorias.AutoSize = true;
            this.lbTodasLasCategorias.Location = new System.Drawing.Point(24, 36);
            this.lbTodasLasCategorias.Name = "lbTodasLasCategorias";
            this.lbTodasLasCategorias.Size = new System.Drawing.Size(109, 13);
            this.lbTodasLasCategorias.TabIndex = 12;
            this.lbTodasLasCategorias.Text = "Todas las Categorias:";
            // 
            // lbCategoriaDetalles
            // 
            this.lbCategoriaDetalles.AutoSize = true;
            this.lbCategoriaDetalles.Location = new System.Drawing.Point(15, 424);
            this.lbCategoriaDetalles.Name = "lbCategoriaDetalles";
            this.lbCategoriaDetalles.Size = new System.Drawing.Size(291, 13);
            this.lbCategoriaDetalles.TabIndex = 11;
            this.lbCategoriaDetalles.Text = "Selecciona una con click izquierdo para modificar o eliminar ";
            // 
            // dvgListadoCategorias
            // 
            this.dvgListadoCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgListadoCategorias.Location = new System.Drawing.Point(27, 66);
            this.dvgListadoCategorias.Name = "dvgListadoCategorias";
            this.dvgListadoCategorias.Size = new System.Drawing.Size(265, 355);
            this.dvgListadoCategorias.TabIndex = 10;
            this.dvgListadoCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgListadoCategorias_CellClick);
            // 
            // AdministrarCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 557);
            this.Controls.Add(this.BotonEliminar);
            this.Controls.Add(this.BotonModificar);
            this.Controls.Add(this.textBoxModificarEliminarCategoria);
            this.Controls.Add(this.botonAgregarCategoria);
            this.Controls.Add(this.textboxNombreCategoria);
            this.Controls.Add(this.lbAgregar);
            this.Controls.Add(this.lbTodasLasCategorias);
            this.Controls.Add(this.lbCategoriaDetalles);
            this.Controls.Add(this.dvgListadoCategorias);
            this.Name = "AdministrarCategorias";
            this.Text = "AdministrarCategorias";
            this.Load += new System.EventHandler(this.AdministrarCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgListadoCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BotonEliminar;
        private System.Windows.Forms.Button BotonModificar;
        private System.Windows.Forms.TextBox textBoxModificarEliminarCategoria;
        private System.Windows.Forms.Button botonAgregarCategoria;
        private System.Windows.Forms.TextBox textboxNombreCategoria;
        private System.Windows.Forms.Label lbAgregar;
        private System.Windows.Forms.Label lbTodasLasCategorias;
        private System.Windows.Forms.Label lbCategoriaDetalles;
        private System.Windows.Forms.DataGridView dvgListadoCategorias;
    }
}