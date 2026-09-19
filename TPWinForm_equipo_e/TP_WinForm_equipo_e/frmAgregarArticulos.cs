using Dominio;
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
    public partial class frmAgregarArticulos : Form
    {
        public frmAgregarArticulos()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgregarArticulos_Load(object sender, EventArgs e)
        {
            MarcaNegocio negocioMar = new MarcaNegocio();
            List<Marca> listaMarcas = negocioMar.Listar();

            CategoriaNegocio negocioCat = new CategoriaNegocio();
            List<Categoria> listaCategorias = negocioCat.Listar();

            try
            {
                pictBImagArticulos.Image = Properties.Resources.ImagenDefault;
                pictBImagArticulos.SizeMode = PictureBoxSizeMode.Zoom;
                cboMarcas.DataSource = listaMarcas;
                cboMarcas.DisplayMember = "Descripcion";
                cboMarcas.ValueMember = "Id";
                cboCategorias.DataSource = listaCategorias;
                cboCategorias.DisplayMember = "Descripcion";
                cboCategorias.ValueMember = "Id";

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void txtbURL_Validating(object sender, CancelEventArgs e)
        {
            string url = txtbURL.Text.Trim();

            // Si el campo está vacío, decidí vos si lo permitís o no
            if (string.IsNullOrWhiteSpace(url))
            {
                // Opción 1: permitir vacío (no cancelar)
                // return;

                // Opción 2: no permitir vacío
                MessageBox.Show("La URL de la imagen es obligatoria.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;   // ← esto evita que se ejecute Validated
                return;
            }

            if (!ImageUrlValidator.IsValidImageUrlQuick(url))
            {
                MessageBox.Show("La dirección de la imagen no parece ser válida.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;   // ← CLAVE: cancela y no deja salir del control
                return;
            }
        }

        private void txtbURL_Validated(object sender, EventArgs e)
        {
            try
            {
                string cadenaImagen = txtbURL.Text.Trim();
                pictBImagArticulos.Load(cadenaImagen);
                pictBImagArticulos.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                // Si llegamos acá es porque la URL tenía buena extensión pero no se pudo cargar
                MessageBox.Show("No se pudo cargar la imagen desde la dirección indicada.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Opcional: volver a poner la imagen por defecto
                pictBImagArticulos.Image = Properties.Resources.ImagenDefault;
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
                Articulo nuevo = new Articulo();
                nuevo.Codigo = txtbCodigo.Text.ToString();
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = (int)cboMarcas.SelectedValue;
                nuevo.Nombre = txtbNombre.Text.ToString();
                nuevo.Descripcion = txtbDescrip.Text.ToString();
                nuevo.Precio = numPrecio.Value;
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = (int)cboCategorias.SelectedValue;


                // ... cargar las propiedades del objeto ...
                // nuevo.UrlImagen = txtbURL.Text.Trim();
                // nuevo.IdMarca = (int)cboMarcas.SelectedValue;
                // etc.

                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.Agregar(nuevo);

                MessageBox.Show("Artículo agregado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
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

            if (!ImageUrlValidator.IsValidImageUrlQuick(url))
            {
                MessageBox.Show("La URL de la imagen no es válida.");
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
            string mensajeError = "El campo es obligatorio";
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
    }
}
