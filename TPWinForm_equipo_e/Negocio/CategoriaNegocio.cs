using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using negocio;

namespace Negocio
{
    internal class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> ListaDeCategorias = new List<Categoria>();
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.setearConsulta("SELECT Id, Descripcion FROM CATEGORIAS");
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Categoria auxiliar = new Categoria();
                    auxiliar.Id = (int)Datos.Lector["Id"];
                    auxiliar.Descripcion = (string)Datos.Lector["Descripcion"];
                    ListaDeCategorias.Add(auxiliar);
                }

                return ListaDeCategorias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }
    }
}