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

            // Enganchamos el evento Enter de los 4 textboxes de URL
            // para previsualizar la imagen al recibir el foco.
            txtbURL.Enter += TxtbURL_Enter;
            txtbURL2.Enter += TxtbURL_Enter;
            txtbURL3.Enter += TxtbURL_Enter;
            txtbURL4.Enter += TxtbURL_Enter;
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
                    // Cargamos la primera imagen disponible (o default)
                    cargarImagen(txtbURL.Text.Trim());
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
                    numPrecio.Value = ArticuloSeleccionado.Precio;
                else
                    numPrecio.Value = numPrecio.Minimum;

                cboMarcas.SelectedValue = ArticuloSeleccionado.Marca.Id;
                cboCategorias.SelectedValue = ArticuloSeleccionado.Categoria.Id;

                // Asignamos hasta 4 imágenes a los textboxes.
                TextBox[] urls = { txtbURL, txtbURL2, txtbURL3, txtbURL4 };
                var imagenes = ArticuloSeleccionado.Imagenes ?? new List<Imagen>();

                for (int i = 0; i < urls.Length; i++)
                {
                    urls[i].Text = (i < imagenes.Count) ? imagenes[i].ImagenUrl : string.Empty;
                }
            }
            catch (Exception)
            {
                // Silencioso. No pongo nada acá.
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
            catch (Exception)
            {
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
                pictBImagArticulos.SizeMode = PictureBoxSizeMode.Zoom;
                cboMarcas.DataSource = listaMarcas;
                cboMarcas.DisplayMember = "Descripcion";
                cboMarcas.ValueMember = "Id";
                cboCategorias.DataSource = listaCategorias;
                cboCategorias.DisplayMember = "Descripcion";
                cboCategorias.ValueMember = "Id";
                cboMarcas.DropDownStyle = ComboBoxStyle.DropDownList;
                cboCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
                settearControles();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

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

        /// <summary>
        /// Devuelve las URLs cargadas en los 4 textboxes, sin las vacías.
        /// </summary>
        private List<string> ObtenerUrlsCargadas()
        {
            var urls = new List<string>();
            TextBox[] cajas = { txtbURL, txtbURL2, txtbURL3, txtbURL4 };

            foreach (var tb in cajas)
            {
                string url = tb.Text.Trim();
                if (!string.IsNullOrEmpty(url))
                    urls.Add(url);
            }

            return urls;
        }

        private void AgregarArticulo()
        {
            Articulo nuevo = ArmarArticulo();

            ArticuloNegocio negocio = new ArticuloNegocio();
            int idArticulo = negocio.Agregar(nuevo);

            ImagenNegocio imaNegocio = new ImagenNegocio();
            foreach (string url in ObtenerUrlsCargadas())
            {
                Imagen nuevaIma = new Imagen(idArticulo, url);
                imaNegocio.Agregar(nuevaIma);
            }

            MessageBox.Show("Artículo agregado correctamente.");
        }

        private void ModificarArticulo()
        {
            Articulo articulo = ArmarArticulo();
            articulo.Id = ArticuloSeleccionado.Id;

            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.Modificar(articulo);

            // Sincronizamos las imágenes: actualizamos las existentes,
            // insertamos las nuevas y eliminamos las sobrantes.
            ImagenNegocio imaNegocio = new ImagenNegocio();

            List<string> urlsNuevas = ObtenerUrlsCargadas();
            List<Imagen> imagenesActuales = ArticuloSeleccionado.Imagenes ?? new List<Imagen>();

            int cantidadExistente = imagenesActuales.Count;
            int cantidadNueva = urlsNuevas.Count;

            // Actualizar las que ya existían (mismo índice)
            for (int i = 0; i < Math.Min(cantidadExistente, cantidadNueva); i++)
            {
                Imagen imagenModificada = new Imagen
                {
                    Id = imagenesActuales[i].Id,
                    IdArticulo = articulo.Id,
                    ImagenUrl = urlsNuevas[i]
                };
                imaNegocio.Modificar(imagenModificada);
            }

            // Insertar las nuevas (si el usuario agregó más URLs)
            for (int i = cantidadExistente; i < cantidadNueva; i++)
            {
                Imagen nuevaIma = new Imagen(articulo.Id, urlsNuevas[i]);
                imaNegocio.Agregar(nuevaIma);
            }

            // Eliminar las sobrantes (si el usuario quitó URLs)
            for (int i = cantidadNueva; i < cantidadExistente; i++)
            {
                imaNegocio.Eliminar(imagenesActuales[i].Id);
            }

            MessageBox.Show("Artículo modificado correctamente.");
        }

        private bool ValidarFormulario()
        {
            string url = txtbURL.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("La primera URL de la imagen es obligatoria.");
                txtbURL.Focus();
                return false;
            }

            if (!ValidarCampoObligatorio(txtbCodigo, 50, "código")) return false;
            if (!ValidarCampoObligatorio(txtbNombre, 50, "nombre")) return false;
            if (!ValidarCampoObligatorio(txtbDescrip, 150, "descripción")) return false;

            return true;
        }

        private bool ValidarCampoObligatorio(TextBox textBox, int largoCadena, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"El campo {nombreCampo} es obligatorio", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
                return false;
            }
            if (textBox.Text.Length > largoCadena)
            {
                string mensaje = (nombreCampo == "descripción")
                    ? "El texto de la descripción es muy grande."
                    : $"El texto del {nombreCampo} es muy grande.";

                MessageBox.Show(mensaje, "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Al entrar en foco a cualquiera de los 4 textboxes de URL,
        /// previsualizamos esa imagen. Si el foco pasa a otro control,
        /// no se modifica la imagen mostrada.
        /// </summary>
        private void TxtbURL_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null) return;

            cargarImagen(tb.Text.Trim());
        }

        // Opcional: mantener el feedback en vivo mientras se pega una URL.
        private void txtbURL_TextChanged(object sender, EventArgs e)
        {
            // Solo actualizamos si el textbox que dispara el evento tiene el foco,
            // para no pisar la previsualización al cambiar otros controles.
            if (sender is TextBox tb && tb.Focused)
                cargarImagen(tb.Text.Trim());
        }
    }
}