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
        

        public AdministrarArticulos()
        {
            InitializeComponent();
        }

        private void listadoArticulos_Load(object sender, EventArgs e)
        {
            pbxArticulos.SizeMode = PictureBoxSizeMode.StretchImage;
            cargarArticulos();
        }

        public void cargarArticulos()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.Listar();
                dgvArticulos.DataSource = listaArticulos;
                //ocultarColumnas();

               
                if (listaArticulos.Count == 0)
                    cargarImagen(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            if (dgvArticulos.Columns["Imagenes"] != null)
                dgvArticulos.Columns["Imagenes"].Visible = false;
            if (dgvArticulos.Columns["Id"] != null)
                dgvArticulos.Columns["Id"].Visible = false;
        }



        private void cargarImagen(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    pbxArticulos.Image = Properties.Resources.ImagenDefault;
                else
                    pbxArticulos.Load(url);
            }
            catch (Exception ex)
            {
                // URL rota o sin conexión
                
                pbxArticulos.Image = Properties.Resources.ImagenDefault;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            cargarArticulos();
           
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
                return;

            Articulo seleccionado = dgvArticulos.CurrentRow.DataBoundItem as Articulo;
            if (seleccionado == null)
                return;

            string url = seleccionado.Imagenes.FirstOrDefault()?.ImagenUrl;
            cargarImagen(url);

            /*
            if (dgvArticulos.CurrentRow == null)
                return;

            Articulo seleccionado = dgvArticulos.CurrentRow.DataBoundItem as Articulo;
            if (seleccionado == null)
                return;

            string url = seleccionado.Imagenes != null && seleccionado.Imagenes.Count > 0
       ? seleccionado.Imagenes[0].ImagenUrl
       : null;

            cargarImagen(seleccionado.Id.ToString());
            */
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
    }
}
