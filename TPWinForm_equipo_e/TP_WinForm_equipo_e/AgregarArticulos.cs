using Dominio;
using negocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_WinForm_equipo_e
{
    public enum ModoFormulario
    {
        Agregar,
        Modificar
    }
    public partial class AgregarArticulos : Form
    {
        public ModoFormulario Modo { get; set; }
        public Articulo ArticuloSeleccionado { get; set; }
        public int idImagenSeleccionad { get; set; }

        public AgregarArticulos()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settearControles()
        {
            switch (Modo)
            {
                case ModoFormulario.Agregar:
                    this.Text = "Agregar artículos";
                    btnAgregar.Text = "Agregar";
                    pictBImagArticulos.Image = Properties.Resources.ImagenDefault;
                    break;
                case ModoFormulario.Modificar:
                    this.Text = "Modificar artículos";
                    btnAgregar.Text = "Modificar";
                    cargarDatosCampos();
                    cargarImagen(txtbURL.Text.ToString());

                    break;
            }
        }
        private void cargarDatosCampos()
        {
            try
            {
                
                txtbCodigo.Text = ArticuloSeleccionado.Codigo;
                txtbNombre.Text = ArticuloSeleccionado.Nombre;
                txtbDescrip.Text = ArticuloSeleccionado.Descripcion;
                if (ArticuloSeleccionado.Precio > 0)
                {
                    numPrecio.Value = ArticuloSeleccionado.Precio;
                }
                else
                {
                    numPrecio.Value = numPrecio.Minimum;
                }


                cboMarcas.SelectedValue = ArticuloSeleccionado.Marca.Id;
                cboCategorias.SelectedValue = ArticuloSeleccionado.Categoria.Id;
                var imagenSeleccionada = ArticuloSeleccionado.Imagenes.FirstOrDefault();

                if (imagenSeleccionada != null)
                {
                    txtbURL.Text = imagenSeleccionada.ImagenUrl;
                    // Guardás el Id en una variable para usarlo después
                    int idImagen = imagenSeleccionada.Id;
                }
            }
            catch (Exception)
            {

           
            }
            
            

        }

        private void cargarImagen(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    pictBImagArticulos.Image = Properties.Resources.ImagenDefault;
                else
                    pictBImagArticulos.Load(url);
            }
            catch (Exception ex)
            {
                // URL rota o sin conexión

                pictBImagArticulos.Image = Properties.Resources.ImagenDefault;
            }
        }
        private void frmAgregarArticulos_Load(object sender, EventArgs e)
        {
            
            numPrecio.Minimum = 1;
            MarcaNegocio negocioMar = new MarcaNegocio();
            List<Marca> listaMarcas = negocioMar.Listar();

            CategoriaNegocio negocioCat = new CategoriaNegocio();
            List<Categoria> listaCategorias = negocioCat.Listar();

            try
            {
                //pictBImagArticulos.Image = Properties.Resources.ImagenDefault;
                pictBImagArticulos.SizeMode = PictureBoxSizeMode.Zoom;
                cboMarcas.DataSource = listaMarcas;
                cboMarcas.DisplayMember = "Descripcion";
                cboMarcas.ValueMember = "Id";
                cboCategorias.DataSource = listaCategorias;
                cboCategorias.DisplayMember = "Descripcion";
                cboCategorias.ValueMember = "Id";

                settearControles();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        

        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // 1. Validar que todos los campos estén bien
            if (!ValidarFormulario())
                return;   // Si algo falla, no sigue

            // 2. Si llegó acá, todo está ok → guardar en la BD
            try
            {

                switch (Modo)
                {
                    case ModoFormulario.Agregar:
                        AgregarArticulo();
                        break;
                    case ModoFormulario.Modificar:
                        ModificarArticulo();

                        break;
                }
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private Articulo ArmarArticulo()
        {
            Articulo articulo = new Articulo();

            articulo.Codigo = txtbCodigo.Text.Trim();
            articulo.Nombre = txtbNombre.Text.Trim();
            articulo.Descripcion = txtbDescrip.Text.Trim();
            articulo.Precio = numPrecio.Value;

            articulo.Marca = new Marca { Id = (int)cboMarcas.SelectedValue };
            articulo.Categoria = new Categoria { Id = (int)cboCategorias.SelectedValue };

            return articulo;
        }

        private void AgregarArticulo()
        {
            Articulo nuevo = ArmarArticulo();

            ArticuloNegocio negocio = new ArticuloNegocio();
            int idArticulo = negocio.Agregar(nuevo);

            Imagen nuevaIma = new Imagen(idArticulo, txtbURL.Text.Trim());
            ImagenNegocio imaNegocio = new ImagenNegocio();
            imaNegocio.Agregar(nuevaIma);

            MessageBox.Show("Artículo agregado correctamente.");
        }

        private void ModificarArticulo()
        {
            Articulo articulo = ArmarArticulo();
            articulo.Id = ArticuloSeleccionado.Id;

            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.Modificar(articulo);

            // 🔑 Modificar la imagen mostrada
            var imagenSeleccionada = ArticuloSeleccionado.Imagenes.FirstOrDefault();
            if (imagenSeleccionada != null)
            {
                Imagen imagenModificada = new Imagen();
                imagenModificada.Id = imagenSeleccionada.Id; // el Id que ya tenía en la DB
                imagenModificada.IdArticulo = articulo.Id;
                imagenModificada.ImagenUrl = txtbURL.Text.Trim();

                ImagenNegocio imaNegocio = new ImagenNegocio();
                imaNegocio.Modificar(imagenModificada);
            }

            MessageBox.Show("Artículo modificado correctamente.");
        }


        
        
        private bool ValidarFormulario()
        {
            bool esValido = true;
            // Validación de la URL
            string url = txtbURL.Text.Trim();
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("La URL de la imagen es obligatoria.");
                txtbURL.Focus();
                return false;
            }

            esValido = ValidarCampoObligatorio(txtbCodigo, 50);
            esValido = ValidarCampoObligatorio(txtbNombre, 50);
            esValido = ValidarCampoObligatorio(txtbDescrip, 50);
            

            return esValido; // Todo OK
        }

        private bool ValidarCampoObligatorio(TextBox textBox, int largoCadena )
        {
            string mensajeError = $"El campo {textBox.Name} es obligatorio";
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show(mensajeError, "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
                return false;
            }
            if (textBox.Text.Length > largoCadena)
            {
                MessageBox.Show("El texto es muy grande","Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        



        private void txtbURL_TextChanged(object sender, EventArgs e)
        {
            if (txtbURL.Text != null)
            {
                try
                {
                    pictBImagArticulos.Load(txtbURL.Text.ToString());
                }
                catch (Exception)
                {

                    
                }
            }
        }

        
    }
}
