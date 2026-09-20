using Dominio;
using negocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_WinForm_equipo_e
{
    public partial class DetallesArticulo : Form
    {
        private Dominio.Articulo articuloActual;

        public DetallesArticulo(Dominio.Articulo articulo)
        {
            InitializeComponent();
            this.Text = "Detalles del Artículo";

            BotonEliminar.UseVisualStyleBackColor = true;

            articuloActual = articulo;

            lbCodigo.Text = "Código: " + articulo.Codigo;
            lbNombre.Text = "Nombre: " + articulo.Nombre;

            tbxArticuloDescripcion.Text = articulo.Descripcion;

            lbMarca.Text = "Marca: " + (articulo.Marca != null ? articulo.Marca.Descripcion : "Sin marca");
            lbCategoria.Text = "Categoría: " + (articulo.Categoria != null ? articulo.Categoria.Descripcion : "Sin categoría");
            lbPrecio.Text = "Precio: $ " + articulo.Precio.ToString("N2");

            ImagenNegocio imagenesNegocio = new ImagenNegocio();
            List<Imagen> imagenes = imagenesNegocio.Listar(articulo.Id);

            if (imagenes.Count > 0)
            {
                try
                {
                    PictureBoxGrande.Load(imagenes[0].ImagenUrl);
                }
                catch (WebException)
                {
                    PictureBoxGrande.Image = Properties.Resources.ImagenDefault;
                }
            }
            else
            {
                PictureBoxGrande.Image = Properties.Resources.ImagenDefault;
            }
            PictureBoxGrande.SizeMode = PictureBoxSizeMode.Zoom;

            foreach (Imagen imagen in imagenes)
            {
                PictureBox picturebox = new PictureBox();
                picturebox.Size = new Size(80, 74);
                picturebox.Tag = imagen;
                picturebox.Click += Picturebox_Click;

                try
                {
                    picturebox.Load(imagen.ImagenUrl);
                }
                catch (WebException)
                {
                    picturebox.Image = Properties.Resources.ImagenDefault;
                }
                finally
                {
                    PanelFlow.Controls.Add(picturebox);
                    picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void Picturebox_Click(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            Imagen imagen = (Imagen)picturebox.Tag;

            try
            {
                PictureBoxGrande.Load(imagen.ImagenUrl);
            }
            catch (WebException)
            {
                PictureBoxGrande.Image = Properties.Resources.ImagenDefault;
            }
            finally
            {
                PictureBoxGrande.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void DetallesArticulo_Load(object sender, EventArgs e)
        {
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            AgregarArticulos ventana = new AgregarArticulos();
            ventana.Modo = ModoFormulario.Modificar;
            ventana.ArticuloSeleccionado = articuloActual;
            ventana.idImagenSeleccionad = 0;
            ventana.ShowDialog();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                $"¿Estás seguro de que querés eliminar el artículo '{articuloActual.Nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.Eliminar(articuloActual.Id);

                    MessageBox.Show("Artículo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetallesArticulo_Load_1(object sender, EventArgs e)
        {
        }
        private void lbNombre_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}