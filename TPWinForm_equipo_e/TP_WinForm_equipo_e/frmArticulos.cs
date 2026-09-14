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
    public partial class frmArticulos : Form
    {
        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                dgvArticulos.DataSource = negocio.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ESTO ES PARA PROBAR QUE SE CREA CON EXITO LUEGO REEMPLAZARLO POR UN FORMULARIO CORRESPONDIENTE 
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo nuevo = new Articulo();

            try
            {
                nuevo.Codigo = "TST01";
                nuevo.Nombre = "Celular Test";
                nuevo.Descripcion = "Probando inserción jerárquica";
                nuevo.Precio = 5555.55m;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = 1;

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = 1;

                nuevo.Imagenes.Add(new Imagen { ImagenUrl = "https://images.unsplash.com/photo-1.jpg" });

                negocio.Agregar(nuevo);

                MessageBox.Show("¡Artículo e imagen agregados con éxito :P");

                dgvArticulos.DataSource = negocio.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
