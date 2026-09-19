namespace TP_WinForm_equipo_e
{
    partial class AdministrarMarca
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
            this.dvgListadoMarcas = new System.Windows.Forms.DataGridView();
            this.lbMarcaDetalles = new System.Windows.Forms.Label();
            this.lbTodasLasMarcas = new System.Windows.Forms.Label();
            this.lbAgregar = new System.Windows.Forms.Label();
            this.textboxNombreMarca = new System.Windows.Forms.TextBox();
            this.botonAgregarMarca = new System.Windows.Forms.Button();
            this.textBoxModificarEliminarMarca = new System.Windows.Forms.TextBox();
            this.BotonModificar = new System.Windows.Forms.Button();
            this.BotonEliminar = new System.Windows.Forms.Button();
            this.btnVolverMarcas = new System.Windows.Forms.Button();
            this.lblMarcaAgregar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgListadoMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgListadoMarcas
            // 
            this.dvgListadoMarcas.BackgroundColor = System.Drawing.Color.White;
            this.dvgListadoMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgListadoMarcas.Location = new System.Drawing.Point(24, 79);
            this.dvgListadoMarcas.Name = "dvgListadoMarcas";
            this.dvgListadoMarcas.Size = new System.Drawing.Size(265, 224);
            this.dvgListadoMarcas.TabIndex = 1;
            this.dvgListadoMarcas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgListadoMarcas_CellClick);
            // 
            // lbMarcaDetalles
            // 
            this.lbMarcaDetalles.AutoSize = true;
            this.lbMarcaDetalles.Location = new System.Drawing.Point(21, 348);
            this.lbMarcaDetalles.Name = "lbMarcaDetalles";
            this.lbMarcaDetalles.Size = new System.Drawing.Size(285, 13);
            this.lbMarcaDetalles.TabIndex = 2;
            this.lbMarcaDetalles.Text = "Seleccione una con clic izquierdo para modificar o eliminar ";
            // 
            // lbTodasLasMarcas
            // 
            this.lbTodasLasMarcas.AutoSize = true;
            this.lbTodasLasMarcas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTodasLasMarcas.Location = new System.Drawing.Point(21, 36);
            this.lbTodasLasMarcas.Name = "lbTodasLasMarcas";
            this.lbTodasLasMarcas.Size = new System.Drawing.Size(119, 16);
            this.lbTodasLasMarcas.TabIndex = 3;
            this.lbTodasLasMarcas.Text = "Todas las marcas:";
            // 
            // lbAgregar
            // 
            this.lbAgregar.AutoSize = true;
            this.lbAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAgregar.Location = new System.Drawing.Point(338, 79);
            this.lbAgregar.Name = "lbAgregar";
            this.lbAgregar.Size = new System.Drawing.Size(103, 16);
            this.lbAgregar.TabIndex = 4;
            this.lbAgregar.Text = "Agregar Marca: ";
            // 
            // textboxNombreMarca
            // 
            this.textboxNombreMarca.Location = new System.Drawing.Point(341, 109);
            this.textboxNombreMarca.Name = "textboxNombreMarca";
            this.textboxNombreMarca.Size = new System.Drawing.Size(154, 20);
            this.textboxNombreMarca.TabIndex = 5;
            // 
            // botonAgregarMarca
            // 
            this.botonAgregarMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonAgregarMarca.Location = new System.Drawing.Point(515, 103);
            this.botonAgregarMarca.Name = "botonAgregarMarca";
            this.botonAgregarMarca.Size = new System.Drawing.Size(88, 30);
            this.botonAgregarMarca.TabIndex = 6;
            this.botonAgregarMarca.Text = "Agregar";
            this.botonAgregarMarca.UseVisualStyleBackColor = true;
            this.botonAgregarMarca.Click += new System.EventHandler(this.botonAgregarMarca_Click);
            // 
            // textBoxModificarEliminarMarca
            // 
            this.textBoxModificarEliminarMarca.Location = new System.Drawing.Point(341, 237);
            this.textBoxModificarEliminarMarca.Name = "textBoxModificarEliminarMarca";
            this.textBoxModificarEliminarMarca.Size = new System.Drawing.Size(195, 20);
            this.textBoxModificarEliminarMarca.TabIndex = 7;
            // 
            // BotonModificar
            // 
            this.BotonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonModificar.Location = new System.Drawing.Point(341, 273);
            this.BotonModificar.Name = "BotonModificar";
            this.BotonModificar.Size = new System.Drawing.Size(88, 30);
            this.BotonModificar.TabIndex = 8;
            this.BotonModificar.Text = "Modificar";
            this.BotonModificar.UseVisualStyleBackColor = true;
            this.BotonModificar.Click += new System.EventHandler(this.BotonModificar_Click);
            // 
            // BotonEliminar
            // 
            this.BotonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonEliminar.Location = new System.Drawing.Point(448, 273);
            this.BotonEliminar.Name = "BotonEliminar";
            this.BotonEliminar.Size = new System.Drawing.Size(88, 30);
            this.BotonEliminar.TabIndex = 9;
            this.BotonEliminar.Text = "Eliminar";
            this.BotonEliminar.UseVisualStyleBackColor = true;
            this.BotonEliminar.Click += new System.EventHandler(this.BotonEliminar_Click);
            // 
            // btnVolverMarcas
            // 
            this.btnVolverMarcas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverMarcas.Location = new System.Drawing.Point(394, 346);
            this.btnVolverMarcas.Name = "btnVolverMarcas";
            this.btnVolverMarcas.Size = new System.Drawing.Size(77, 29);
            this.btnVolverMarcas.TabIndex = 10;
            this.btnVolverMarcas.Text = "Volver";
            this.btnVolverMarcas.UseVisualStyleBackColor = true;
            this.btnVolverMarcas.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblMarcaAgregar
            // 
            this.lblMarcaAgregar.AutoSize = true;
            this.lblMarcaAgregar.Location = new System.Drawing.Point(347, 156);
            this.lblMarcaAgregar.Name = "lblMarcaAgregar";
            this.lblMarcaAgregar.Size = new System.Drawing.Size(0, 13);
            this.lblMarcaAgregar.TabIndex = 11;
            // 
            // AdministrarMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 398);
            this.Controls.Add(this.lblMarcaAgregar);
            this.Controls.Add(this.btnVolverMarcas);
            this.Controls.Add(this.BotonEliminar);
            this.Controls.Add(this.BotonModificar);
            this.Controls.Add(this.textBoxModificarEliminarMarca);
            this.Controls.Add(this.botonAgregarMarca);
            this.Controls.Add(this.textboxNombreMarca);
            this.Controls.Add(this.lbAgregar);
            this.Controls.Add(this.lbTodasLasMarcas);
            this.Controls.Add(this.lbMarcaDetalles);
            this.Controls.Add(this.dvgListadoMarcas);
            this.Name = "AdministrarMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Marcas";
            this.Load += new System.EventHandler(this.AdministrarMarca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgListadoMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgListadoMarcas;
        private System.Windows.Forms.Label lbMarcaDetalles;
        private System.Windows.Forms.Label lbTodasLasMarcas;
        private System.Windows.Forms.Label lbAgregar;
        private System.Windows.Forms.TextBox textboxNombreMarca;
        private System.Windows.Forms.Button botonAgregarMarca;
        private System.Windows.Forms.TextBox textBoxModificarEliminarMarca;
        private System.Windows.Forms.Button BotonModificar;
        private System.Windows.Forms.Button BotonEliminar;
        private System.Windows.Forms.Button btnVolverMarcas;
        private System.Windows.Forms.Label lblMarcaAgregar;
    }
}