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

                ImagenNegocio imagenNegocio = new ImagenNegocio();

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

                    // 🔑 Cargar imágenes desde la DB
                    aux.Imagenes = imagenNegocio.Listar(aux.Id);

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

        /*
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
        */

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

        public List<Articulo> Filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string columna = "";
                string condicion = "";


                if (campo == "Nombre")
                {
                    columna = "A.Nombre";
                }
                else if (campo == "Codigo")
                {
                    columna = "A.Codigo";
                }
                else if (campo == "Precio")
                {
                    columna = "A.Precio";
                }


                if (criterio == "Contiene")
                {
                    condicion = " LIKE ";
                    filtro = "%" + filtro + "%";
                }
                else if (criterio == "Comienza con")
                {
                    condicion = " LIKE ";
                    filtro = filtro + "%";
                }
                else if (criterio == "Termina con")
                {
                    condicion = " LIKE ";
                    filtro = "%" + filtro;
                }
                else if (criterio == "Igual a")
                {
                    condicion = " = ";
                }
                else if (criterio == "Mayor que")
                {
                    condicion = " > ";
                }
                else if (criterio == "Menor que")
                {
                    condicion = " < ";
                }

                string where = " WHERE " + columna + condicion + "@filtro";

                datos.setearConsulta(
                    "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, " +
                    "A.IdMarca, M.Descripcion AS Marca, " +
                    "A.IdCategoria, C.Descripcion AS Categoria, A.Precio " +
                    "FROM ARTICULOS A " +
                    "LEFT JOIN MARCAS M ON M.Id = A.IdMarca " +
                    "LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria" +
                    where
                );

                datos.setearParametro("@filtro", filtro);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    if (datos.Lector["IdMarca"] != DBNull.Value)
                    {
                        aux.Marca = new Marca();
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }

                    if (datos.Lector["IdCategoria"] != DBNull.Value)
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void Modificar(Articulo Articulo)
        {
            AccesoDatos Base = new AccesoDatos();

            try
            {
                Base.setearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion,     IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE Id = @id;");

                Base.setearParametro("@codigo", Articulo.Codigo);
                Base.setearParametro("@nombre", Articulo.Nombre);
                Base.setearParametro("@descripcion", Articulo.Descripcion);
                Base.setearParametro("@idMarca", Articulo.Marca != null ? (object)Articulo.Marca.Id : DBNull.Value);
                Base.setearParametro("@idCategoria", Articulo.Categoria != null ? (object)Articulo.Categoria.Id : DBNull.Value);
                Base.setearParametro("@precio", Articulo.Precio);
                Base.setearParametro("@id", Articulo.Id);

                Base.ejecutarAccion();
            }
            catch
            {
                throw;
            }
            finally
            {
                Base.cerrarConexion();
            }



        }






    }





}