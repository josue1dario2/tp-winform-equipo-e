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
    public partial class AgregarArticulos : Form
    {
        public AgregarArticulos()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
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
                
                //nuevaIma.ImagenUrl = txtbURL.Text.ToString();




                ArticuloNegocio negocio = new ArticuloNegocio();
                int idArticulo = negocio.Agregar(nuevo);

                Imagen nuevaIma = new Imagen(idArticulo, txtbURL.Text.Trim());

                ImagenNegocio imaNegocio = new ImagenNegocio();
                imaNegocio.Agregar(nuevaIma);




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
