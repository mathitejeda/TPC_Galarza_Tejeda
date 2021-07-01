using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Productos
    {
        public string nombre;
        public string detalle;
        public int numeroSerie;
        public string condicion;

        public Productos(string nombre)
        {
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return nombre;
        }
    }
}
