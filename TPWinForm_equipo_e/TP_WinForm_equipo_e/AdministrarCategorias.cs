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
        }

        public void cargarCategorias()
        {
            CategoriaNegocio listado = new CategoriaNegocio();
            dvgListadoCategorias.DataSource = listado.Listar();
        }

        private void AdministrarCategorias_Load(object sender, EventArgs e)
        {
            cargarCategorias();
        }

        private void botonAgregarCategoria_Click(object sender, EventArgs e)
        {
            Categoria ParaAgregar = new Categoria();
            CategoriaNegocio Agregador = new CategoriaNegocio();

            ParaAgregar.Descripcion = textboxNombreCategoria.Text;

            Agregador.Agregar(ParaAgregar);
            cargarCategorias();
        }

        private void dvgListadoCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;

            Categoria categoria = (Categoria)dvgListadoCategorias.Rows[e.RowIndex].DataBoundItem;

            textBoxModificarEliminarCategoria.Text = categoria.Descripcion;

            IdCategoriaSeleccionada = categoria.Id;
        }

        private void BotonModificar_Click(object sender, EventArgs e)
        {
            if (IdCategoriaSeleccionada == 0)
            {
                MessageBox.Show("No se selecciono Categoria a cambiar");
            }
            else
            {
                Categoria modificar = new Categoria();
                CategoriaNegocio aplicar = new CategoriaNegocio();

                modificar.Id = IdCategoriaSeleccionada;
                modificar.Descripcion = textBoxModificarEliminarCategoria.Text;



                aplicar.Modificar(modificar);
                cargarCategorias();

            }
        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            if (IdCategoriaSeleccionada == 0)
            {
                MessageBox.Show("No se selecciono Categorias a Eliminar");
            }
            else
            {
                Categoria Eliminar = new Categoria();
                CategoriaNegocio aplicar = new CategoriaNegocio();

                Eliminar.Id = IdCategoriaSeleccionada;




                aplicar.Eliminar(Eliminar.Id);
                cargarCategorias();
            }
        }
    }
}