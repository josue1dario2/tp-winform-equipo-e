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
    public partial class AdministrarCategorias : Form
    {
        private int IdCategoriaSeleccionada;

        public AdministrarCategorias()
        {
            InitializeComponent();
            this.Text = "Administrar Categorías";
        }

        public void cargarCategorias()
        {
            CategoriaNegocio listado = new CategoriaNegocio();
            dvgListadoCategorias.DataSource = listado.Listar();

            if (dvgListadoCategorias.Columns["Id"] != null)
                dvgListadoCategorias.Columns["Id"].Visible = false;

            if (dvgListadoCategorias.Columns["Descripcion"] != null)
            {
                dvgListadoCategorias.Columns["Descripcion"].HeaderText = "Descripción";
                dvgListadoCategorias.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dvgListadoCategorias.ColumnHeadersDefaultCellStyle.Font = new Font(dvgListadoCategorias.Font, FontStyle.Bold);
        }

        private void AdministrarCategorias_Load(object sender, EventArgs e)
        {
            cargarCategorias();
            IdCategoriaSeleccionada = 0;
            if (lblCategoriaAgregar != null) lblCategoriaAgregar.Text = "";
        }

        private void botonAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textboxNombreCategoria.Text))
            {
                MessageBox.Show("Por favor, ingresá el nombre de la categoría (no puede estar vacío ni tener solo espacios).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreCategoria = textboxNombreCategoria.Text.Trim();
            Categoria ParaAgregar = new Categoria();
            CategoriaNegocio Agregador = new CategoriaNegocio();

            ParaAgregar.Descripcion = nombreCategoria;
            Agregador.Agregar(ParaAgregar);

            if (lblCategoriaAgregar != null)
            {
                lblCategoriaAgregar.Text = $"La categoría se agregó correctamente.";
                lblCategoriaAgregar.ForeColor = Color.ForestGreen;
            }

            textboxNombreCategoria.Clear();
            textboxNombreCategoria.Focus();
            cargarCategorias();
        }

        private void dvgListadoCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Categoria categoria = (Categoria)dvgListadoCategorias.Rows[e.RowIndex].DataBoundItem;

                textBoxModificarEliminarCategoria.Text = categoria.Descripcion;
                IdCategoriaSeleccionada = categoria.Id;

                if (lblCategoriaAgregar != null) lblCategoriaAgregar.Text = "";
            }
        }

        private void BotonModificar_Click(object sender, EventArgs e)
        {
            if (IdCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccioná una categoría de la lista para modificar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxModificarEliminarCategoria.Text))
            {
                MessageBox.Show("La descripción no puede estar vacía ni contener únicamente espacios en blanco.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show("¿Estás seguro de que querés modificar esta categoría?", "Confirmar modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Categoria modificar = new Categoria();
                CategoriaNegocio aplicar = new CategoriaNegocio();

                modificar.Id = IdCategoriaSeleccionada;
                modificar.Descripcion = textBoxModificarEliminarCategoria.Text.Trim();

                aplicar.Modificar(modificar);
                cargarCategorias();

                if (lblCategoriaAgregar != null)
                {
                    lblCategoriaAgregar.Text = "La categoría se modificó exitosamente.";
                    lblCategoriaAgregar.ForeColor = Color.ForestGreen;
                }

                textBoxModificarEliminarCategoria.Clear();
                IdCategoriaSeleccionada = 0;
            }
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            if (IdCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Por favor, seleccioná una categoría de la lista para eliminar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Estás seguro de que querés eliminar esta categoría?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    CategoriaNegocio aplicar = new CategoriaNegocio();

                    aplicar.Eliminar(IdCategoriaSeleccionada);

                    if (lblCategoriaAgregar != null)
                    {
                        lblCategoriaAgregar.Text = "La categoría se eliminó correctamente.";
                        lblCategoriaAgregar.ForeColor = Color.ForestGreen;
                    }

                    textBoxModificarEliminarCategoria.Clear();
                    IdCategoriaSeleccionada = 0;
                    cargarCategorias();
                }
            }
        }

        private void btnVolverCategorias_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbTodasLasCategorias_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}