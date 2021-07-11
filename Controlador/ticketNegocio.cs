using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class ticketNegocio
    {
        public List<Ticket> listar()
        {
            List<Ticket> lista = new List<Ticket>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta =
                    "select T.IDTicket, ET.nombre,CLI.nombre, TEC.nombre, T.FechaIngreso,p.nombre " +
                    "from ticket as T " +
                    "inner join estadoTicket as ET on T.IDEstado=ET.nombre " +
                    "inner join usuarios as TEC on T.IDTecnico=TEC.IDUsuario " +
                    "inner join usuarios as CLI on T.IDCliente=CLI.IDUsuario " +
                    "inner join productos as P on T.IDProducto=P.IDProducto";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Ticket aux = new Ticket();
                    aux.idTicket = datos.Lector.GetInt32(0);
                    aux.Estado = new EstadoTicket(datos.Lector.GetString(1));
                    aux.cliente = new Usuario(datos.Lector.GetString(2));
                    aux.tecnico = new Usuario(datos.Lector.GetString(3));
                    aux.fechaIngreso = datos.Lector.GetDateTime(4);
                    aux.producto = new Productos(datos.Lector.GetString(5));
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Ticket detalle(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Ticket aux = new Ticket();
            try
            {
                string consulta =
                    "select T.IDTicket, ET.nombre,CLI.nombre, TEC.nombre, T.FechaIngreso,p.nombre " +
                    "from ticket as T " +
                    "inner join estadoTicket as ET on T.IDEstado=ET.IDEstado " +
                    "inner join usuarios as TEC on T.IDTecnico=TEC.IDUsuario " +
                    "inner join usuarios as CLI on T.IDCliente=CLI.IDUsuario " +
                    "inner join productos as P on T.IDProducto=P.IDProducto " +
                    "where T.IDTicket="+id;
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    aux.idTicket = datos.Lector.GetInt32(0);
                    aux.Estado = new EstadoTicket(datos.Lector.GetString(1));
                    aux.cliente = new Usuario(datos.Lector.GetString(2));
                    aux.tecnico = new Usuario(datos.Lector.GetString(3));
                    aux.fechaIngreso = datos.Lector.GetDateTime(4);
                    aux.producto = new Productos(datos.Lector.GetString(5));
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearTicket(Ticket ticket){
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("insert into Ticket(IDCliente, IDProducto,IDServicio, problema) values(@idcliente,@idproducto,@idservicio,@problema)");
                datos.setParametro("@idcliente",ticket.cliente.Id);
                datos.setParametro("@idproducto",ticket.producto.id);
                datos.setParametro("@idservicio",ticket.servicios.IDTipo);
                datos.setParametro("@problema",ticket.problema);

                datos.ejecutarAccion();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
