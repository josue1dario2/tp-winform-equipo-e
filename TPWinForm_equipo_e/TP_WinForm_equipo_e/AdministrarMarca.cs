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

            if(dvgListadoMarcas.Columns["Id"] != null)
                dvgListadoMarcas.Columns["Id"].Visible = false;

            if (dvgListadoMarcas.Columns["Descripcion"] != null)
                dvgListadoMarcas.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void AdministrarMarca_Load(object sender, EventArgs e)
        {
            cargarMarcas();
            IdMarcaSeleccionada = 0;
        }

        private void botonAgregarMarca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textboxNombreMarca.Text))
            {
                MessageBox.Show("Por favor, ingresá el nombre de la marca.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Marca ParaAgregar = new Marca();
            MarcaNegocio Agregador=new MarcaNegocio();

            ParaAgregar.Descripcion = textboxNombreMarca.Text;

            Agregador.Agregar(ParaAgregar);

            textboxNombreMarca.Clear();
            textboxNombreMarca.Focus();
            cargarMarcas();
        }



        private void dvgListadoMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila=e.RowIndex;

            Marca marca = (Marca)dvgListadoMarcas.Rows[e.RowIndex].DataBoundItem;

            textBoxModificarEliminarMarca.Text = marca.Descripcion;

            IdMarcaSeleccionada = marca.Id;
        }

        private void BotonModificar_Click(object sender, EventArgs e)
        {
            if(IdMarcaSeleccionada==0)
            {
                MessageBox.Show("No se selecciono Marca a cambiar");
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("seguro que quiere modificar esta Marca?", "seguro Quiere modificar?", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    Marca modificar = new Marca();
                    MarcaNegocio aplicar = new MarcaNegocio();

                    modificar.Id = IdMarcaSeleccionada;
                    modificar.Descripcion = textBoxModificarEliminarMarca.Text;



                    aplicar.Modificar(modificar);
                    cargarMarcas();
                }
            }    




        }

        private void BotonEliminar_Click(object sender, EventArgs e)
        {
            if (IdMarcaSeleccionada == 0)
            {
                MessageBox.Show("No se selecciono Marca a Eliminar");
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("seguro que quiere Eliminar esta Marca?", "seguro Quiere Eliminar?", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    Marca Eliminar = new Marca();
                    MarcaNegocio aplicar = new MarcaNegocio();

                    Eliminar.Id = IdMarcaSeleccionada;

                    textBoxModificarEliminarMarca.Clear();
                    IdMarcaSeleccionada = 0;


                    aplicar.Eliminar(Eliminar.Id);
                    cargarMarcas();
                }
            }
        }
  
    
    
    
    
    
    
    
    }

}
