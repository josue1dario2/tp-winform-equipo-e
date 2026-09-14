using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using negocio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS Marca, A.IdCategoria, C.Descripcion AS Categoria, A.Precio FROM ARTICULOS A LEFT JOIN MARCAS M ON M.Id = A.IdMarca LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = !(datos.Lector["Codigo"] is DBNull) ? (string)datos.Lector["Codigo"] : string.Empty;
                    aux.Nombre = !(datos.Lector["Nombre"] is DBNull) ? (string)datos.Lector["Nombre"] : string.Empty;
                    aux.Descripcion = !(datos.Lector["Descripcion"] is DBNull) ? (string)datos.Lector["Descripcion"] : string.Empty;

                    aux.Marca = new Marca();
                    aux.Marca.Id = !(datos.Lector["IdMarca"] is DBNull) ? (int)datos.Lector["IdMarca"] : 0;
                    aux.Marca.Descripcion = !(datos.Lector["Marca"] is DBNull) ? (string)datos.Lector["Marca"] : string.Empty;

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = !(datos.Lector["IdCategoria"] is DBNull) ? (int)datos.Lector["IdCategoria"] : 0;
                    aux.Categoria.Descripcion = !(datos.Lector["Categoria"] is DBNull) ? (string)datos.Lector["Categoria"] : string.Empty;

                    aux.Precio = !(datos.Lector["Precio"] is DBNull) ? (decimal)datos.Lector["Precio"] : 0m;

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
