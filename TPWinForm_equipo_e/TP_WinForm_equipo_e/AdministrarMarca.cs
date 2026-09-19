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
using Dominio;

namespace TP_WinForm_equipo_e
{
    public partial class AdministrarMarca : Form
    {
        private int IdMarcaSeleccionada;
        public AdministrarMarca()
        {
            InitializeComponent();
            this.Text = "Administrar Marca";
        }

        public void cargarMarcas()
        {
            MarcaNegocio listado = new MarcaNegocio();
            dvgListadoMarcas.DataSource = listado.Listar();

            if (dvgListadoMarcas.Columns["Id"] != null)
                dvgListadoMarcas.Columns["Id"].Visible = false;

            if (dvgListadoMarcas.Columns["Descripcion"] != null)
            {
                dvgListadoMarcas.Columns["Descripcion"].HeaderText = "Descripción";
                dvgListadoMarcas.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dvgListadoMarcas.ColumnHeadersDefaultCellStyle.Font = new Font(dvgListadoMarcas.Font, FontStyle.Bold);
        }

        private void AdministrarMarca_Load(object sender, EventArgs e)
        {
            cargarMarcas();
            IdMarcaSeleccionada = 0;
            lblMarcaAgregar.Text = ""; 
        }

        private void botonAgregarMarca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textboxNombreMarca.Text))
            {
                MessageBox.Show("Por favor, ingresá el nombre de la marca.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreMarca = textboxNombreMarca.Text.Trim();
            Marca ParaAgregar = new Marca();
            MarcaNegocio Agregador = new MarcaNegocio();

            ParaAgregar.Descripcion = nombreMarca;
            Agregador.Agregar(ParaAgregar);

            lblMarcaAgregar.Text = $"La marca se agregó correctamente.";
            lblMarcaAgregar.ForeColor = Color.ForestGreen;

            textboxNombreMarca.Clear();
            textboxNombreMarca.Focus();
            cargarMarcas();
        }

        private void dvgListadoMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int fila = e.RowIndex;
                Marca marca = (Marca)dvgListadoMarcas.Rows[e.RowIndex].DataBoundItem;

                textBoxModificarEliminarMarca.Text = marca.Descripcion;
                IdMarcaSeleccionada = marca.Id;

                lblMarcaAgregar.Text = "";
            }
        }

        private void BotonModificar_Click(object sender, EventArgs e)
        {
            if (IdMarcaSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccioná una marca de la lista para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Estás seguro de que querés modificar esta marca?", "Confirmar modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    Marca modificar = new Marca();
                    MarcaNegocio aplicar = new MarcaNegocio();

                    modificar.Id = IdMarcaSeleccionada;
                    modificar.Descripcion = textBoxModificarEliminarMarca.Text.Trim();

                    aplicar.Modificar(modificar);
                    cargarMarcas();

                    lblMarcaAgregar.Text = $"La marca se modificó exitosamente.";
                    lblMarcaAgregar.ForeColor = Color.ForestGreen;

                    textBoxModificarEliminarMarca.Clear();
                    IdMarcaSeleccionada = 0;
                }
            }
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            if (IdMarcaSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccioná una marca de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Estás seguro de que querés eliminar esta marca?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    MarcaNegocio aplicar = new MarcaNegocio();

                    aplicar.Eliminar(IdMarcaSeleccionada);

                    lblMarcaAgregar.Text = $"La marca se eliminó correctamente.";
                    lblMarcaAgregar.ForeColor = Color.ForestGreen;

                    textBoxModificarEliminarMarca.Clear();
                    IdMarcaSeleccionada = 0;
                    cargarMarcas();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}