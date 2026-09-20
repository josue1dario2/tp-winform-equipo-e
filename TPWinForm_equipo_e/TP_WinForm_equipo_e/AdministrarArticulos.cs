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
    public partial class AdministrarArticulos : Form
    {
        private List<Articulo> listaArticulos;
        private Articulo articuloModificar;

        public AdministrarArticulos()
        {
            InitializeComponent();
        }

        public AdministrarArticulos(Articulo articulo)
        {
            InitializeComponent();
            articuloModificar = articulo;
        }

        private void listadoArticulos_Load(object sender, EventArgs e)
        {
            pbxArticulos.SizeMode = PictureBoxSizeMode.Zoom;
            dgvArticulos.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvArticulos_CellFormatting);
            cargarArticulos();
        }

        public void cargarArticulos()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.Listar();
                dgvArticulos.DataSource = listaArticulos;

                cultarYFormatearColumnas();

                if (listaArticulos.Count == 0)
                {
                    cargarImagen(null);
                    LimpiarFichaDetalle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cultarYFormatearColumnas()
        {
            if (dgvArticulos.Columns["Imagenes"] != null)
                dgvArticulos.Columns["Imagenes"].Visible = false;
            if (dgvArticulos.Columns["Id"] != null)
                dgvArticulos.Columns["Id"].Visible = false;

            if (dgvArticulos.Columns["Codigo"] != null) dgvArticulos.Columns["Codigo"].HeaderText = "Código";
            if (dgvArticulos.Columns["Descripcion"] != null) dgvArticulos.Columns["Descripcion"].HeaderText = "Descripción";
            if (dgvArticulos.Columns["Categoria"] != null) dgvArticulos.Columns["Categoria"].HeaderText = "Categoría";

            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvArticulos.Font, FontStyle.Bold);

            if (dgvArticulos.Columns["Precio"] != null)
            {
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void dgvArticulos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvArticulos.Columns[e.ColumnIndex].Name == "Precio" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal precio))
                {
                    e.Value = "$ " + precio.ToString("0.##");
                    e.FormattingApplied = true;
                }
            }
        }

        private void cargarImagen(string url)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url))
                {
                    pbxArticulos.Image = Properties.Resources.ImagenDefault;
                }
                else
                {
                    pbxArticulos.Load(url.Trim());
                }
            }
            catch (Exception)
            {
                pbxArticulos.Image = Properties.Resources.ImagenDefault;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
                return;

            Articulo seleccionado = dgvArticulos.CurrentRow.DataBoundItem as Articulo;
            if (seleccionado == null)
                return;

            string url = null;
            if (seleccionado.Imagenes != null && seleccionado.Imagenes.Count > 0)
            {
                url = seleccionado.Imagenes[0].ImagenUrl;
            }

            cargarImagen(url);

            string marca = seleccionado.Marca != null ? seleccionado.Marca.Descripcion : "Sin marca";
            string precioStr = "$ " + seleccionado.Precio.ToString("0.##");
            string descripcion = string.IsNullOrWhiteSpace(seleccionado.Descripcion) ? "Sin descripción" : seleccionado.Descripcion;

            if (lblDetalleProducto != null)
            {
                lblDetalleProducto.Text = $"{seleccionado.Nombre}\n{marca}  |  {precioStr}\n{descripcion}";
            }
        }

        private void LimpiarFichaDetalle()
        {
            if (lblDetalleProducto != null)
            {
                lblDetalleProducto.Text = "Sin artículos disponibles";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                    DialogResult respuesta = MessageBox.Show(
                        $"¿Estás seguro de que querés eliminar el artículo '{seleccionado.Nombre}'?",
                        "Eliminando artículo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (respuesta == DialogResult.Yes)
                    {
                        negocio.Eliminar(seleccionado.Id);
                        cargarArticulos();
                        MessageBox.Show("¡Artículo e imágenes eliminados correctamente!");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccioná un artículo de la lista para poder eliminarlo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarArticulos ventana = new AgregarArticulos();
            ventana.Modo = ModoFormulario.Agregar;
            ventana.ShowDialog();
        }

        private void AdministrarArticulos_Activated(object sender, EventArgs e)
        {
            cargarArticulos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                AgregarArticulos ventana = new AgregarArticulos();
                ventana.Modo = ModoFormulario.Modificar;
                ventana.ArticuloSeleccionado = seleccionado;
                ventana.idImagenSeleccionad = 0;
                ventana.ShowDialog();

                cargarArticulos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccioná un artículo para modificar.");
            }
        }
    }
}