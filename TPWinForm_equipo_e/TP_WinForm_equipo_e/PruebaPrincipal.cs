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
        private string placeholderText = "Ingrese artículo a buscar...";

        public PruebaPrincipal()
        {
            InitializeComponent();
        }

        private void PruebaPrincipal_Load(object sender, EventArgs e)
        {
            txtFiltro.Text = placeholderText;
            txtFiltro.ForeColor = Color.Gray;

            btnFiltrar.Click -= btnFiltrar_Click;
            btnFiltrar.Click += btnFiltrar_Click;

            txtFiltro.MouseDown -= txtFiltro_MouseDown;
            txtFiltro.MouseDown += txtFiltro_MouseDown;

            txtPrecioMin.KeyPress += txtSoloNumeros_KeyPress;
            txtPrecioMax.KeyPress += txtSoloNumeros_KeyPress;

            CargarFiltros();
            CargarArticulos();
        }

        private void CargarFiltros()
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> listaMarcas = marcaNegocio.Listar();
                listaMarcas.Insert(0, new Marca { Id = 0, Descripcion = "Todas" });
                cboMarca.DataSource = listaMarcas;
                cboMarca.DisplayMember = "Descripcion";
                cboMarca.ValueMember = "Id";
                cboMarca.DropDownStyle = ComboBoxStyle.DropDownList;

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> listaCategorias = categoriaNegocio.Listar();
                listaCategorias.Insert(0, new Categoria { Id = 0, Descripcion = "Todas" });
                cboCategoria.DataSource = listaCategorias;
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.ValueMember = "Id";
                cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
                txtPrecioMin.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltro_Enter(object sender, EventArgs e)
        {
            if (txtFiltro.Text == placeholderText)
            {
                txtFiltro.Text = "";
                txtFiltro.ForeColor = Color.Black;
            }
        }

        private void txtFiltro_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtFiltro.Text == placeholderText)
            {
                txtFiltro.Text = "";
                txtFiltro.ForeColor = Color.Black;
            }
        }

        private void txtFiltro_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFiltro.Text))
            {
                txtFiltro.Text = placeholderText;
                txtFiltro.ForeColor = Color.Gray;
            }
        }

        private void txtSoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true; 
            }

            TextBox txt = sender as TextBox;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (txt.Text.Contains(",") || txt.Text.Contains(".")))
            {
                e.Handled = true;
            }
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
            MostrarArticulosEnPantalla(lista, imagenNegocio);
        }

        private void MostrarArticulosEnPantalla(List<Articulo> lista, ImagenNegocio imagenNegocio)
        {
            flowLayoutPanel1.Controls.Clear();

            if (lista.Count == 0)
            {
                Label lblAviso = new Label();
                lblAviso.Text = "No se encontraron artículos relacionados.";
                lblAviso.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
                lblAviso.ForeColor = Color.DimGray;
                lblAviso.AutoSize = true;
                lblAviso.Margin = new Padding(30, 40, 0, 0);

                flowLayoutPanel1.Controls.Add(lblAviso);
                return;
            }

            foreach (Articulo articulo in lista)
            {
                Panel panel = new Panel();
                panel.Size = new Size(210, 260);
                panel.BorderStyle = BorderStyle.FixedSingle;

                PictureBox pictureBox = new PictureBox();
                List<Imagen> imagenes = imagenNegocio.Listar(articulo.Id);

                pictureBox.Location = new Point(0, 0);
                pictureBox.Size = new Size(210, 137);

                if (imagenes.Count > 0 && !string.IsNullOrWhiteSpace(imagenes[0].ImagenUrl))
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtFiltro.Text.Trim();
                if (nombre == placeholderText)
                    nombre = "";

                int idMarca = cboMarca.SelectedValue != null ? Convert.ToInt32(cboMarca.SelectedValue) : 0;
                int idCategoria = cboCategoria.SelectedValue != null ? Convert.ToInt32(cboCategoria.SelectedValue) : 0;

                decimal precioMin = 0;
                decimal precioMax = 0;

                if (!string.IsNullOrEmpty(txtPrecioMin.Text) && decimal.TryParse(txtPrecioMin.Text, out decimal min))
                    precioMin = min;

                if (!string.IsNullOrEmpty(txtPrecioMax.Text) && decimal.TryParse(txtPrecioMax.Text, out decimal max))
                    precioMax = max;

                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaFiltrada = negocio.FiltrarAvanzado(nombre, idMarca, idCategoria, precioMin, precioMax);

                ImagenNegocio imagenNegocio = new ImagenNegocio();
                MostrarArticulosEnPantalla(listaFiltrada, imagenNegocio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}