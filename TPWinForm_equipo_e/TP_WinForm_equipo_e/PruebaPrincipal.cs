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
    public partial class PruebaPrincipal : Form
    {
        public PruebaPrincipal()
        {
            InitializeComponent();
        }

        private void PruebaPrincipal_Load(object sender, EventArgs e)
        {

           ArticuloNegocio negocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            List<Articulo> lista=negocio.Listar();


            foreach (Articulo articulo in lista)
            {



                Panel panel = new Panel();
                panel.Size = new Size(210, 292);

                Label lbNombre = new Label();
                lbNombre.Location = new Point(3, 140);
                lbNombre.Size = new Size(44, 13);
                lbNombre.Text = articulo.Nombre;

                Label lbMarca = new Label();
                lbMarca.Location = new Point(3, 168);
                lbMarca.Size = new Size(37, 13);
                lbMarca.Text = articulo.Marca.Descripcion;

                Label lbCategoria = new Label();
                lbCategoria.Location = new Point(3, 198);
                lbCategoria.Size = new Size(52, 13);
                lbCategoria.Text = articulo.Categoria.Descripcion;


                Label lbPrecio = new Label();
                lbPrecio.Location = new Point(3, 225);
                lbPrecio.Size = new Size(37, 13);
                lbPrecio.Text = articulo.Precio.ToString();


                PictureBox pictureBox = new PictureBox();
                List<Imagen> imagenes = imagenNegocio.Listar(articulo.Id);



                pictureBox.Location = new Point(-3, 0);
                pictureBox.Size = new Size(210, 137);

                if (imagenes.Count > 0)
                { pictureBox.Image = Properties.Resources.ImagenDefault; }
                else
                { pictureBox.Image=Properties.Resources.ImagenDefault; }
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                
                   
                    
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lbNombre);
                panel.Controls.Add(lbMarca);
                panel.Controls.Add(lbCategoria);
                panel.Controls.Add(lbPrecio); 

                flowLayoutPanel1.Controls.Add(panel);



            }







        }

        private void listadoDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listadoArticulos ventana = new listadoArticulos();
            ventana.ShowDialog();
        }
    }
}
