using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Ticket
    {
        public int idTicket;
        public Productos producto;
        public Usuario cliente;
        public Usuario tecnico;
        public string detalle;
        public string estado;
        public DateTime fechaIngreso;
        public DateTime fechaFinalizacion;
    }
}
