using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP_WinForm_equipo_e
{
    internal class MarcaNegocio
    {
        public List<Marca> Listar()

        {
            try
            {
                SqlConnection Conexion = new SqlConnection();

                Conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_P3_DB;integrated security=true";


                SqlCommand Comando = new SqlCommand();

                Comando.CommandType = System.Data.CommandType.Text;

                Comando.Connection = Conexion;

                Conexion.Open();

                Comando.CommandText = "SELECT Id,Descripcion FROM MARCAS";

                SqlDataReader Lector = Comando.ExecuteReader();

                List<Marca> ListaDeMarcas = new List<Marca>();
                while (Lector.Read())
                {

                    Marca Auxiliar = new Marca();

                    Auxiliar.Id = (int)Lector["Id"];
                    Auxiliar.Descripcion = (string)Lector["Descripcion"];
                    ListaDeMarcas.Add(Auxiliar);


                }

                return ListaDeMarcas;
            }

             catch 
            {

                throw;
            }


        }

    }
}
