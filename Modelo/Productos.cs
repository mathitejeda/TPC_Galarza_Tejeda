using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Productos
    {
        public long id;
        public string nombre;
        public string detalle;
        public long numeroSerie;

        public Productos(string nombre)
        {
            this.nombre = nombre;
        }
        public Productos() { }
        public override string ToString()
        {
            return nombre;
        }
    }
}
