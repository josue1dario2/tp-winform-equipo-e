namespace TP_WinForm_equipo_e
{
    partial class AgregarArticulos
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtbCodigo = new System.Windows.Forms.TextBox();
            this.txtbNombre = new System.Windows.Forms.TextBox();
            this.txtbDescrip = new System.Windows.Forms.TextBox();
            this.cboCategorias = new System.Windows.Forms.ComboBox();
            this.cboMarcas = new System.Windows.Forms.ComboBox();
            this.lblImagen = new System.Windows.Forms.Label();
            this.txtbURL = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pictBImagArticulos = new System.Windows.Forms.PictureBox();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.txtbURL2 = new System.Windows.Forms.TextBox();
            this.lblImagen2 = new System.Windows.Forms.Label();
            this.lblImagen3 = new System.Windows.Forms.Label();
            this.txtbURL3 = new System.Windows.Forms.TextBox();
            this.txtbURL4 = new System.Windows.Forms.TextBox();
            this.lblImagen4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictBImagArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(310, 420);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(105, 36);
            this.btnVolver.TabIndex = 11;
            this.btnVolver.Text = "&Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(75, 30);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(66, 20);
            this.lblCodigo.TabIndex = 4;
            this.lblCodigo.Text = "Código:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(69, 65);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 20);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(37, 97);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(104, 20);
            this.lblDescripcion.TabIndex = 6;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(81, 134);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(62, 20);
            this.lblPrecio.TabIndex = 7;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(80, 308);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(61, 20);
            this.lblMarca.TabIndex = 8;
            this.lblMarca.Text = "Marca:";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(55, 343);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(86, 20);
            this.lblCategoria.TabIndex = 9;
            this.lblCategoria.Text = "Categoría:";
            // 
            // txtbCodigo
            // 
            this.txtbCodigo.Location = new System.Drawing.Point(163, 31);
            this.txtbCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbCodigo.Name = "txtbCodigo";
            this.txtbCodigo.Size = new System.Drawing.Size(252, 22);
            this.txtbCodigo.TabIndex = 0;
            // 
            // txtbNombre
            // 
            this.txtbNombre.Location = new System.Drawing.Point(163, 66);
            this.txtbNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbNombre.Name = "txtbNombre";
            this.txtbNombre.Size = new System.Drawing.Size(252, 22);
            this.txtbNombre.TabIndex = 1;
            // 
            // txtbDescrip
            // 
            this.txtbDescrip.Location = new System.Drawing.Point(163, 98);
            this.txtbDescrip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbDescrip.Name = "txtbDescrip";
            this.txtbDescrip.Size = new System.Drawing.Size(252, 22);
            this.txtbDescrip.TabIndex = 2;
            // 
            // cboCategorias
            // 
            this.cboCategorias.FormattingEnabled = true;
            this.cboCategorias.Location = new System.Drawing.Point(162, 339);
            this.cboCategorias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCategorias.MaximumSize = new System.Drawing.Size(151, 0);
            this.cboCategorias.MinimumSize = new System.Drawing.Size(151, 0);
            this.cboCategorias.Name = "cboCategorias";
            this.cboCategorias.Size = new System.Drawing.Size(151, 24);
            this.cboCategorias.TabIndex = 9;
            // 
            // cboMarcas
            // 
            this.cboMarcas.FormattingEnabled = true;
            this.cboMarcas.Location = new System.Drawing.Point(162, 304);
            this.cboMarcas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboMarcas.MaximumSize = new System.Drawing.Size(151, 0);
            this.cboMarcas.MinimumSize = new System.Drawing.Size(151, 0);
            this.cboMarcas.Name = "cboMarcas";
            this.cboMarcas.Size = new System.Drawing.Size(151, 24);
            this.cboMarcas.TabIndex = 8;
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = true;
            this.lblImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagen.Location = new System.Drawing.Point(34, 172);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(107, 20);
            this.lblImagen.TabIndex = 17;
            this.lblImagen.Text = "URL Imagen:";
            // 
            // txtbURL
            // 
            this.txtbURL.Location = new System.Drawing.Point(163, 172);
            this.txtbURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbURL.Name = "txtbURL";
            this.txtbURL.Size = new System.Drawing.Size(252, 22);
            this.txtbURL.TabIndex = 4;
            this.txtbURL.TextChanged += new System.EventHandler(this.txtbURL_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(162, 420);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(105, 36);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pictBImagArticulos
            // 
            this.pictBImagArticulos.Location = new System.Drawing.Point(463, 30);
            this.pictBImagArticulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictBImagArticulos.Name = "pictBImagArticulos";
            this.pictBImagArticulos.Size = new System.Drawing.Size(347, 273);
            this.pictBImagArticulos.TabIndex = 20;
            this.pictBImagArticulos.TabStop = false;
            // 
            // numPrecio
            // 
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Location = new System.Drawing.Point(164, 137);
            this.numPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numPrecio.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(120, 22);
            this.numPrecio.TabIndex = 3;
            // 
            // txtbURL2
            // 
            this.txtbURL2.Location = new System.Drawing.Point(163, 205);
            this.txtbURL2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbURL2.Name = "txtbURL2";
            this.txtbURL2.Size = new System.Drawing.Size(252, 22);
            this.txtbURL2.TabIndex = 5;
            // 
            // lblImagen2
            // 
            this.lblImagen2.AutoSize = true;
            this.lblImagen2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagen2.Location = new System.Drawing.Point(34, 207);
            this.lblImagen2.Name = "lblImagen2";
            this.lblImagen2.Size = new System.Drawing.Size(107, 20);
            this.lblImagen2.TabIndex = 22;
            this.lblImagen2.Text = "URL Imagen:";
            // 
            // lblImagen3
            // 
            this.lblImagen3.AutoSize = true;
            this.lblImagen3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagen3.Location = new System.Drawing.Point(34, 240);
            this.lblImagen3.Name = "lblImagen3";
            this.lblImagen3.Size = new System.Drawing.Size(107, 20);
            this.lblImagen3.TabIndex = 23;
            this.lblImagen3.Text = "URL Imagen:";
            // 
            // txtbURL3
            // 
            this.txtbURL3.Location = new System.Drawing.Point(163, 240);
            this.txtbURL3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbURL3.Name = "txtbURL3";
            this.txtbURL3.Size = new System.Drawing.Size(252, 22);
            this.txtbURL3.TabIndex = 6;
            // 
            // txtbURL4
            // 
            this.txtbURL4.Location = new System.Drawing.Point(162, 269);
            this.txtbURL4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbURL4.Name = "txtbURL4";
            this.txtbURL4.Size = new System.Drawing.Size(252, 22);
            this.txtbURL4.TabIndex = 7;
            // 
            // lblImagen4
            // 
            this.lblImagen4.AutoSize = true;
            this.lblImagen4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagen4.Location = new System.Drawing.Point(34, 269);
            this.lblImagen4.Name = "lblImagen4";
            this.lblImagen4.Size = new System.Drawing.Size(107, 20);
            this.lblImagen4.TabIndex = 26;
            this.lblImagen4.Text = "URL Imagen:";
            // 
            // AgregarArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 597);
            this.Controls.Add(this.lblImagen4);
            this.Controls.Add(this.txtbURL4);
            this.Controls.Add(this.txtbURL3);
            this.Controls.Add(this.lblImagen3);
            this.Controls.Add(this.txtbURL2);
            this.Controls.Add(this.lblImagen2);
            this.Controls.Add(this.numPrecio);
            this.Controls.Add(this.pictBImagArticulos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtbURL);
            this.Controls.Add(this.lblImagen);
            this.Controls.Add(this.cboMarcas);
            this.Controls.Add(this.cboCategorias);
            this.Controls.Add(this.txtbDescrip);
            this.Controls.Add(this.txtbNombre);
            this.Controls.Add(this.txtbCodigo);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AgregarArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Articulos";
            this.Load += new System.EventHandler(this.frmAgregarArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictBImagArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtbCodigo;
        private System.Windows.Forms.TextBox txtbNombre;
        private System.Windows.Forms.TextBox txtbDescrip;
        private System.Windows.Forms.ComboBox cboCategorias;
        private System.Windows.Forms.ComboBox cboMarcas;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.TextBox txtbURL;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.PictureBox pictBImagArticulos;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.TextBox txtbURL2;
        private System.Windows.Forms.Label lblImagen2;
        private System.Windows.Forms.Label lblImagen3;
        private System.Windows.Forms.TextBox txtbURL3;
        private System.Windows.Forms.TextBox txtbURL4;
        private System.Windows.Forms.Label lblImagen4;
    }
}