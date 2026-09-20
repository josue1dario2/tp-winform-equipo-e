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
    public partial class PruebaPrincipal : Form
    {
        public PruebaPrincipal()
        {
            InitializeComponent();
        }

        private void PruebaPrincipal_Load(object sender, EventArgs e)
        {
            CargarArticulos();
        }

        private void listadoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrarArticulos ventana = new AdministrarArticulos();
            ventana.ShowDialog();
            CargarArticulos();
        }

        private void btnVerMas_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag is Articulo articulo)
            {
                DetallesArticulo detalles = new DetallesArticulo(articulo);
                detalles.ShowDialog();
                CargarArticulos(); 
            }
        }

        private void agregarMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrarMarca ventana = new AdministrarMarca();
            ventana.ShowDialog();
            CargarArticulos();
        }

        private void listadoDeCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministrarCategorias ventana = new AdministrarCategorias();
            ventana.ShowDialog();
            CargarArticulos();
        }

        private void CargarArticulos()
        {
            flowLayoutPanel1.Controls.Clear(); 

            ArticuloNegocio negocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            List<Articulo> lista = negocio.Listar();

            foreach (Articulo articulo in lista)
            {
                Panel panel = new Panel();
                panel.Size = new Size(210, 260);
                panel.BorderStyle = BorderStyle.FixedSingle;

                PictureBox pictureBox = new PictureBox();
                List<Imagen> imagenes = imagenNegocio.Listar(articulo.Id);

                pictureBox.Location = new Point(0, 0);
                pictureBox.Size = new Size(210, 137);

                if (imagenes.Count > 0)
                {
                    try
                    {
                        pictureBox.Load(imagenes[0].ImagenUrl);
                    }
                    catch (WebException)
                    {
                        pictureBox.Image = Properties.Resources.ImagenDefault;
                    }
                }
                else
                {
                    pictureBox.Image = Properties.Resources.ImagenDefault;
                }
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                Label lbInfo = new Label();
                lbInfo.Location = new Point(10, 145);
                lbInfo.Size = new Size(190, 40);
                string marcaDesc = articulo.Marca != null ? articulo.Marca.Descripcion : "";
                lbInfo.Text = marcaDesc + " " + articulo.Nombre;
                lbInfo.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Bold);

                Button btnVerMas = new Button();
                btnVerMas.Text = "Ver más";
                btnVerMas.Location = new Point(10, 195);
                btnVerMas.Size = new Size(190, 35);
                btnVerMas.Tag = articulo;
                btnVerMas.Click += btnVerMas_Click;

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lbInfo);
                panel.Controls.Add(btnVerMas);

                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void DetallesArticulo_Load_1(object sender, EventArgs e)
        {
        }
    }
}