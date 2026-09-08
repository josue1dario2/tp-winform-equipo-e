using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_WinForm_equipo_e
{
    internal class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }

        public List<Imagen> Imagenes { get; set; } = new List<Imagen>();

        public Articulo()
        {
        }

        // Constructor con datos básicos (sin Id, útil al dar de alta uno nuevo)
        public Articulo(string codigo, string nombre, string descripcion, decimal precio, Marca marca, Categoria categoria)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Marca = marca;
            Categoria = categoria;
        }

        // Constructor completo, con Id (útil cuando el repositorio arma el objeto desde la DB)
        public Articulo(int id, string codigo, string nombre, string descripcion, decimal precio, Marca marca, Categoria categoria, List<Imagen> imagenes)
            : this(codigo, nombre, descripcion, precio, marca, categoria)
        {
            Id = id;
            Imagenes = imagenes ?? new List<Imagen>();
        }

        public override string ToString()
        {
            return $"{Codigo} - {Nombre}";
        }
    }
}
