using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
        public class EstadoTicket
        {
            public int IDEstado { get; set; }
            public string Nombre { get; set; }
            public override string ToString()
            {
                return Nombre;
            }
        public EstadoTicket() { }
        public EstadoTicket(string nombre) {
            Nombre = nombre;
        }
        public EstadoTicket(int id, string nombre)
        {
            IDEstado = id;
            Nombre = nombre;
        }
        }
}
