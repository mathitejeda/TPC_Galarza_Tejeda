using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ListaTicket
    {
        public int IdTicket { get; set; }
        public int IDEstado { get; set; }
        public int IdCliente { get; set; }
        public int IdTecnico { get; set; }
        public int IdProducto { get; set; }
        public String Estado { get; set; }
        public String Cliente { get; set; }
        public String Tecnico { get; set; }
        public DateTime FechaIngreso { get; set; }
        public String Producto { get; set; }
        
    }
}
