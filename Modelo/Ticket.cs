using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Ticket
    {
        int id;
        Productos producto;
        int idUsuario;
        int idTecnico;
        string detalle;
        int estado;
        DateTime fechaIngreso;
        DateTime fechaFinalizacion;
    }
}
