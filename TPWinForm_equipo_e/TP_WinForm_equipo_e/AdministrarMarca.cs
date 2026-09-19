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
        }


        public void cargarMarcas()
        {
            MarcaNegocio listado = new MarcaNegocio();
            dvgListadoMarcas.DataSource = listado.Listar();
        }

        private void AdministrarMarca_Load(object sender, EventArgs e)
        {
            cargarMarcas();
        }

        private void botonAgregarMarca_Click(object sender, EventArgs e)
        {
            Marca ParaAgregar = new Marca();
            MarcaNegocio Agregador=new MarcaNegocio();

            ParaAgregar.Descripcion = textboxNombreMarca.Text;

            Agregador.Agregar(ParaAgregar);
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
                Marca modificar = new Marca();
                MarcaNegocio aplicar = new MarcaNegocio();

                modificar.Id = IdMarcaSeleccionada;
                modificar.Descripcion = textBoxModificarEliminarMarca.Text;



                aplicar.Modificar(modificar);
                cargarMarcas();

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
                Marca Eliminar = new Marca();
                MarcaNegocio aplicar = new MarcaNegocio();

                Eliminar.Id = IdMarcaSeleccionada;
                



                aplicar.Eliminar(Eliminar.Id);
                cargarMarcas();

            }
        }
  
    
    
    
    
    
    
    
    }

}
