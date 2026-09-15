using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using negocio;
using Utilitarios;

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

                    aux.Id = datos.Lector.SafeInt("Id");
                    aux.Codigo = datos.Lector.SafeString("Codigo");
                    aux.Nombre = datos.Lector.SafeString("Nombre");
                    aux.Descripcion = datos.Lector.SafeString("Descripcion");

                    aux.Marca = new Marca();
                    aux.Marca.Id = datos.Lector.SafeInt("IdMarca");
                    aux.Marca.Descripcion = datos.Lector.SafeString("Marca");

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = datos.Lector.SafeInt("IdCategoria");
                    aux.Categoria.Descripcion = datos.Lector.SafeString("Categoria");

                    aux.Precio = datos.Lector.SafeDecimal("Precio");

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