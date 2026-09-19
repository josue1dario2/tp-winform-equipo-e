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
//using System.Data.SqlClient;

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
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.Listar();
            dgvArticulos.DataSource = listaArticulos;

            //pbxArticulos.Load(listaArticulos[0].Im
                //.Imagenes.ToString());
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            cargarArticulos();
           
        }
    }
}
