using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_WinForm_equipo_e
{
    internal class Imagen
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public string ImagenUrl { get; set; }

        // Constructor vacío
        public Imagen()
        {
        }

        // Constructor sin Id: para cuando se agrega una imagen nueva a un artículo
        // (el Id lo asigna la base de datos al insertar, por el IDENTITY)
        public Imagen(int idArticulo, string imagenUrl)
        {
            IdArticulo = idArticulo;
            ImagenUrl = imagenUrl;
        }

        // Constructor completo: para cuando el repositorio arma el objeto leyéndolo de la DB
        public Imagen(int id, int idArticulo, string imagenUrl)
            : this(idArticulo, imagenUrl)
        {
            Id = id;
        }

        public override string ToString()
        {
            return ImagenUrl;
        }
    }
}
