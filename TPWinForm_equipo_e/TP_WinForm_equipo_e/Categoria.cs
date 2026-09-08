using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_WinForm_equipo_e
{
    internal class Categoria
    {

        public int Id { get; set; }

        public string Descripcion { get; set; }

        public Categoria()
        {
        }


        public Categoria(string Descripcion)
        {
            this.Descripcion = Descripcion;
        }

        public override string ToString()
        {
             return Descripcion;
        }



    }
}
