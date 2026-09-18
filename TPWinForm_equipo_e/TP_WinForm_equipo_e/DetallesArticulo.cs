using Dominio;
using negocio;
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
        public DetallesArticulo(Articulo articulo)
        {
            InitializeComponent();




            lbID.Text = "Id: "+articulo.Id.ToString();

            lbCodigo.Text ="Codigo: "+ articulo.Codigo.ToString();

            lbNombre.Text="Nombre: "+articulo.Nombre.ToString();

            lbDescripcion.Text = "Descripcion: "+articulo.Descripcion;

            lbMarca.Text = "Marca: "+articulo.Marca.Descripcion;

            lbCategoria.Text = "Categoria: "+articulo.Categoria.Descripcion;

            lbPrecio.Text = ("$ " + articulo.Precio.ToString());


            ImagenNegocio imagenesNegocio = new ImagenNegocio();

            List<Imagen> imagenes = imagenesNegocio.Listar(articulo.Id);




            if (imagenes.Count > 0)
            {
                try
                {
                    PictureBoxGrande.Load(imagenes[0].ImagenUrl);

                }
                catch (WebException)
                { PictureBoxGrande.Image = Properties.Resources.ImagenDefault; }


            }
            else
            { PictureBoxGrande.Image = Properties.Resources.ImagenDefault; }
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
                catch(WebException)
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

            Imagen imagen =(Imagen)picturebox.Tag;


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




    }
}
