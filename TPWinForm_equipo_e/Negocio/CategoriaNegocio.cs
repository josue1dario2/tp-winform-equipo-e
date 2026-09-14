using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    internal class CategoriaNegocio
    {

    public List <Categoria> Listar()
        {

            SqlConnection Conexion = new SqlConnection();
            try
            {
                

                Conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_P3_DB;integrated security=true";

                SqlCommand Comando = new SqlCommand();

                Comando.Connection = Conexion;

                Conexion.Open();

                Comando.CommandText = "SELECT Id,Descripcion FROM CATEGORIAS";
                
                SqlDataReader Lector = Comando.ExecuteReader();

                List<Categoria> ListaDeCategorias = new List<Categoria>();

                while(Lector.Read())
                {

                    Categoria auxiliar= new Categoria();

                    auxiliar.Id = (int)Lector["Id"];
                    auxiliar.Descripcion = (string)Lector["Descripcion"];
                    ListaDeCategorias.Add(auxiliar);
                }


                return ListaDeCategorias;
            }
            catch
            {
                throw;
            }

            finally
            {
                Conexion.Close();
            }
        }

    }
}
