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
        //public List<Ticket> listar()
        //{
        //    List<Ticket> lista = new List<Ticket>();
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        string consulta =
        //            "select T.IDTicket, ET.nombre,CLI.nombre, TEC.nombre, T.FechaIngreso,p.nombre " +
        //            "from ticket as T " +
        //            "inner join estadoTicket as ET on T.IDEstado=ET.nombre " +
        //            "left join usuarios as TEC on T.IDTecnico=TEC.IDUsuario " +
        //            "inner join usuarios as CLI on T.IDCliente=CLI.IDUsuario " +
        //            "inner join productos as P on T.IDProducto=P.IDProducto";
        //        datos.setConsulta(consulta);
        //        datos.ejecutarLectura();
        //        while (datos.Lector.Read())
        //        {
        //            Ticket aux = new Ticket();
        //            aux.idTicket = datos.Lector.GetInt32(0);
        //            aux.Estado = new EstadoTicket(datos.Lector.GetString(1));
        //            aux.cliente = new Usuario(datos.Lector.GetString(2));
        //            aux.tecnico = string.IsNullOrEmpty(datos.Lector.GetString(3)) ? aux.tecnico = new Usuario("N/A") : new Usuario(datos.Lector.GetString(3));
        //            aux.fechaIngreso = datos.Lector.GetDateTime(4);
        //            aux.producto = new Productos(datos.Lector.GetString(5));
        //            lista.Add(aux);
        //        }
        //        return lista;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
            
        //}


        public List<ListaTicket> listarTicketsClientes(long idCliente)
        {
            List<ListaTicket> lista = new List<ListaTicket>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta =
                    "SELECT T.IDTicket, ET.nombre, ISNULL(TEC.apellido + ' ' + TEC.nombre, 'Sin Asignar') AS TECNICO, T.FechaIngreso, P.nombre " +
                    "FROM Ticket AS T " +
                    "INNER join EstadoTicket as ET on T.IDEstado = ET.IDEstado " +
                    "left join usuarios as TEC on T.IDTecnico = TEC.IDUsuario " +
                    "inner join usuarios as CLI on T.IDCliente = CLI.IDUsuario " +
                    "inner join productos as P on T.IDProducto = P.IDProducto " +
                    "WHERE T.IDCliente = " + idCliente + 
                    " ORDER BY T.IDTicket DESC";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ListaTicket aux = new ListaTicket();
                    aux.IdTicket = datos.Lector.GetInt32(0);
                    aux.Estado = datos.Lector.GetString(1);
                    aux.Tecnico = datos.Lector.GetString(2);
                    aux.FechaIngreso = datos.Lector.GetDateTime(3);
                    aux.Producto = datos.Lector.GetString(4);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        //listado de los tickets que no tienen técnico asignado
        public List<ListaTicket> listarSupervisor()
        {
            List<ListaTicket> lista = new List<ListaTicket>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta =
                    "select T.IDTicket, ET.nombre, CLI.nombre + ' ' + CLI.apellido AS CLIENTE, T.FechaIngreso, P.nombre " +
                    "from Ticket as T " +
                    "inner join EstadoTicket as ET on T.IDEstado = ET.IDEstado " +
                    "left join usuarios as TEC on T.IDTecnico = TEC.IDUsuario " +
                    "inner join usuarios as CLI on T.IDCliente = CLI.IDUsuario " +
                    "inner join productos as P on T.IDProducto = P.IDProducto " +
                    "WHERE T.IDTecnico IS NULL AND ET.nombre NOT LIKE 'Finalizado'";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ListaTicket aux = new ListaTicket();
                    aux.IdTicket = datos.Lector.GetInt32(0);
                    aux.Estado = datos.Lector.GetString(1);
                    aux.Cliente = datos.Lector.GetString(2);
                    aux.FechaIngreso = datos.Lector.GetDateTime(3);
                    aux.Producto = datos.Lector.GetString(4);
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public ListaTicket Detalle(long idticket)
        {
            AccesoDatos datos = new AccesoDatos();
            ListaTicket aux = new ListaTicket();
            try
            {
                string consulta =
                    "select p.nombre, s.NROSerie, t.Problema, isnull(t.Diagnostico, 'Sin Diagnostico'), isnull(t.Solucion, 'Sin solucion'), e.nombre from Ticket as t " +
                    "inner join Productos as p on p.IDProducto = t.IDProducto " +
                    "inner join SerieProducto as S on s.IDProducto = t.IDProducto and s.IDUsuario = t.IDCliente " +
                    "inner join EstadoTicket as e on e.IDEstado = t.IDEstado  " +
                    "where t.IDTicket = " + idticket; 
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    aux.Producto = datos.Lector.GetString(0);
                    aux.NROSerie = datos.Lector.GetInt64(1);
                    aux.problema = datos.Lector.GetString(2);
                    aux.diagnostico = datos.Lector.GetString(3);
                    aux.solucion = datos.Lector.GetString(4);
                    aux.Estado = datos.Lector.GetString(5);
                    return aux;
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool CrearTicket(ListaTicket ticket)
        {
            AccesoDatos datos = new AccesoDatos();
            bool result = false;
            try
            {
                datos.setConsulta("insert into Ticket(IDCliente, IDProducto, problema, FechaIngreso, " +
                    "nroserie, IDServicio) values(@idcliente, @idproducto, @problema, @FechaIngreso, @nroserie, @idservicio)");
                datos.setParametro("@idcliente", ticket.IdCliente);
                datos.setParametro("@idproducto", ticket.IDProducto);
                datos.setParametro("@problema", ticket.problema);
                datos.setParametro("@FechaIngreso", DateTime.Now);
                datos.setParametro("@nroserie", ticket.NROSerie);
                datos.setParametro("@idservicio", ticket.IdServicio);
                datos.ejecutarAccion();
                result = true;

            }
            catch (System.Exception)
            {
                //throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return result;
        }

        public void actualizarTicketTecnico(Ticket ticket)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setConsulta("update ticket set Diagnostico=@diagnostico, solucion=@Solucion,IDEstado=@estado");
                //datos.setParametro("@diagnostico", ticket.detalle);
                //datos.setParametro("@Solucion", ticket.solucion);
                //datos.setParametro("@Estado", ticket.Estado.IDEstado);
                //datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        

    }
}
