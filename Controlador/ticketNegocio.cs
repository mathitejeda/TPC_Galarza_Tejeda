using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    class ticketNegocio
    {
        public List<Ticket> listar()
        {
            List<Ticket> lista = new List<Ticket>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta =
                    "select T.IDTicket, ET.nombre,CLI.nombre, TEC.nombre, T.FechaIngreso,p.nombre" +
                    "from ticket as T " +
                    "inner join estadoTicket as ET on T.IDEstado=ET.IDEstado " +
                    "inner join usuarios as TEC on T.IDTecnico=U1.IDUsuario " +
                    "inner join usuarios as U2 on T.IDCliente=U2.IDUsuario " +
                    "inner join productos as P on T.IDProducto=P.IDProducto";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.lector.Read())
                {
                    Ticket aux = new Ticket();
                    aux.idTicket = datos.lector.GetInt32(0);
                    aux.estado = datos.lector.GetString(1);
                    aux.cliente = new Usuario(datos.lector.GetString(2));
                    aux.tecnico = new Usuario(datos.lector.GetString(3));
                    aux.fechaIngreso = datos.lector.GetDateTime(4);
                    aux.producto = new Productos(datos.lector.GetString(5));
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return lista;
        }
    }
}
