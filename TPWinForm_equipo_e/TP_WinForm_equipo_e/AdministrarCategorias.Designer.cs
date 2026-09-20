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
            this.btnVolverCategorias = new System.Windows.Forms.Button();
            this.lblCategoriaAgregar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgListadoCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // BotonEliminar
            // 
            this.BotonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonEliminar.Location = new System.Drawing.Point(445, 277);
            this.BotonEliminar.Name = "BotonEliminar";
            this.BotonEliminar.Size = new System.Drawing.Size(88, 30);
            this.BotonEliminar.TabIndex = 5;
            this.BotonEliminar.Text = "Eliminar";
            this.BotonEliminar.UseVisualStyleBackColor = true;
            this.BotonEliminar.Click += new System.EventHandler(this.BotonEliminar_Click);
            // 
            // BotonModificar
            // 
            this.BotonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonModificar.Location = new System.Drawing.Point(338, 277);
            this.BotonModificar.Name = "BotonModificar";
            this.BotonModificar.Size = new System.Drawing.Size(88, 30);
            this.BotonModificar.TabIndex = 4;
            this.BotonModificar.Text = "Modificar";
            this.BotonModificar.UseVisualStyleBackColor = true;
            this.BotonModificar.Click += new System.EventHandler(this.BotonModificar_Click);
            // 
            // textBoxModificarEliminarCategoria
            // 
            this.textBoxModificarEliminarCategoria.Location = new System.Drawing.Point(338, 240);
            this.textBoxModificarEliminarCategoria.Name = "textBoxModificarEliminarCategoria";
            this.textBoxModificarEliminarCategoria.Size = new System.Drawing.Size(195, 20);
            this.textBoxModificarEliminarCategoria.TabIndex = 3;
            // 
            // botonAgregarCategoria
            // 
            this.botonAgregarCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarCategoria.Location = new System.Drawing.Point(521, 87);
            this.botonAgregarCategoria.Name = "botonAgregarCategoria";
            this.botonAgregarCategoria.Size = new System.Drawing.Size(88, 30);
            this.botonAgregarCategoria.TabIndex = 1;
            this.botonAgregarCategoria.Text = "Agregar";
            this.botonAgregarCategoria.UseVisualStyleBackColor = true;
            this.botonAgregarCategoria.Click += new System.EventHandler(this.botonAgregarCategoria_Click);
            // 
            // textboxNombreCategoria
            // 
            this.textboxNombreCategoria.Location = new System.Drawing.Point(338, 93);
            this.textboxNombreCategoria.Name = "textboxNombreCategoria";
            this.textboxNombreCategoria.Size = new System.Drawing.Size(159, 20);
            this.textboxNombreCategoria.TabIndex = 0;
            // 
            // lbAgregar
            // 
            this.lbAgregar.AutoSize = true;
            this.lbAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAgregar.Location = new System.Drawing.Point(335, 66);
            this.lbAgregar.Name = "lbAgregar";
            this.lbAgregar.Size = new System.Drawing.Size(124, 16);
            this.lbAgregar.TabIndex = 13;
            this.lbAgregar.Text = "Agregar Categoría: ";
            // 
            // lbTodasLasCategorias
            // 
            this.lbTodasLasCategorias.AutoSize = true;
            this.lbTodasLasCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTodasLasCategorias.Location = new System.Drawing.Point(24, 36);
            this.lbTodasLasCategorias.Name = "lbTodasLasCategorias";
            this.lbTodasLasCategorias.Size = new System.Drawing.Size(140, 16);
            this.lbTodasLasCategorias.TabIndex = 12;
            this.lbTodasLasCategorias.Text = "Todas las Categorías:";
            this.lbTodasLasCategorias.Click += new System.EventHandler(this.lbTodasLasCategorias_Click);
            // 
            // lbCategoriaDetalles
            // 
            this.lbCategoriaDetalles.AutoSize = true;
            this.lbCategoriaDetalles.Location = new System.Drawing.Point(24, 365);
            this.lbCategoriaDetalles.Name = "lbCategoriaDetalles";
            this.lbCategoriaDetalles.Size = new System.Drawing.Size(285, 13);
            this.lbCategoriaDetalles.TabIndex = 11;
            this.lbCategoriaDetalles.Text = "Seleccione una con clic izquierdo para modificar o eliminar ";
            // 
            // dvgListadoCategorias
            // 
            this.dvgListadoCategorias.BackgroundColor = System.Drawing.Color.White;
            this.dvgListadoCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgListadoCategorias.Location = new System.Drawing.Point(27, 66);
            this.dvgListadoCategorias.Name = "dvgListadoCategorias";
            this.dvgListadoCategorias.Size = new System.Drawing.Size(265, 271);
            this.dvgListadoCategorias.TabIndex = 2;
            this.dvgListadoCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgListadoCategorias_CellClick);
            // 
            // btnVolverCategorias
            // 
            this.btnVolverCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverCategorias.Location = new System.Drawing.Point(394, 357);
            this.btnVolverCategorias.Name = "btnVolverCategorias";
            this.btnVolverCategorias.Size = new System.Drawing.Size(80, 29);
            this.btnVolverCategorias.TabIndex = 6;
            this.btnVolverCategorias.Text = "Volver";
            this.btnVolverCategorias.UseVisualStyleBackColor = true;
            this.btnVolverCategorias.Click += new System.EventHandler(this.btnVolverCategorias_Click);
            // 
            // lblCategoriaAgregar
            // 
            this.lblCategoriaAgregar.AutoSize = true;
            this.lblCategoriaAgregar.Location = new System.Drawing.Point(358, 142);
            this.lblCategoriaAgregar.Name = "lblCategoriaAgregar";
            this.lblCategoriaAgregar.Size = new System.Drawing.Size(0, 13);
            this.lblCategoriaAgregar.TabIndex = 20;
            this.lblCategoriaAgregar.Click += new System.EventHandler(this.label1_Click);
            // 
            // AdministrarCategorias
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(637, 410);
            this.Controls.Add(this.lblCategoriaAgregar);
            this.Controls.Add(this.btnVolverCategorias);
            this.Controls.Add(this.BotonEliminar);
            this.Controls.Add(this.BotonModificar);
            this.Controls.Add(this.textBoxModificarEliminarCategoria);
            this.Controls.Add(this.botonAgregarCategoria);
            this.Controls.Add(this.textboxNombreCategoria);
            this.Controls.Add(this.lbAgregar);
            this.Controls.Add(this.lbTodasLasCategorias);
            this.Controls.Add(this.lbCategoriaDetalles);
            this.Controls.Add(this.dvgListadoCategorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AdministrarCategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Categorías";
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
        private System.Windows.Forms.Button btnVolverCategorias;
        private System.Windows.Forms.Label lblCategoriaAgregar;
    }
}