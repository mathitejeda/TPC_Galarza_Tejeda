using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Ticket
    {
        public int idTicket { get; set; }
        public Productos producto { get; set; }
        public Usuario cliente { get; set; }
        public Usuario tecnico
        {
            get; set;
        }
        public string detalle
        {
            get; set;
        }
        public string problema{get;set;}
        public EstadoTicket Estado
        {
            get; set;
        }
        public Servicios servicios { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaFinalizacion { get; set; }
    }
}
