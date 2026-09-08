using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_WinForm_equipo_e
{
    internal class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Marca()
        {
        }

        public Marca(string descripcion)
        {
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
