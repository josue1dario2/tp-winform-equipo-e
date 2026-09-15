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

        public void Agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio); SELECT @@IDENTITY;");

                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca != null ? (object)nuevo.Marca.Id : DBNull.Value);
                datos.setearParametro("@idCategoria", nuevo.Categoria != null ? (object)nuevo.Categoria.Id : DBNull.Value);
                datos.setearParametro("@precio", nuevo.Precio);

                int idArticulo = datos.obtenerId();

                if (nuevo.Imagenes != null && nuevo.Imagenes.Count > 0)
                {
                    foreach (var imagen in nuevo.Imagenes)
                    {
                        AccesoDatos datosImagen = new AccesoDatos();
                        try
                        {
                            datosImagen.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @imagenUrl)");
                            datosImagen.setearParametro("@idArticulo", idArticulo);
                            datosImagen.setearParametro("@imagenUrl", imagen.ImagenUrl);

                            datosImagen.ejecutarAccion();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            datosImagen.cerrarConexion();
                        }
                    }
                }
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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @id; DELETE FROM ARTICULOS WHERE Id = @id;");
                datos.setearParametro("@id", id);

                datos.ejecutarAccion();
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
