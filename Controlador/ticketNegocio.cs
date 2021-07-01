﻿using System;
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
                    "inner join estadoTicket as ET on T.IDEstado=ET.IDEstado " +
                    "inner join usuarios as TEC on T.IDTecnico=TEC.IDUsuario " +
                    "inner join usuarios as CLI on T.IDCliente=CLI.IDUsuario " +
                    "inner join productos as P on T.IDProducto=P.IDProducto";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Ticket aux = new Ticket();
                    aux.idTicket = datos.Lector.GetInt32(0);
                    aux.estado = datos.Lector.GetString(1);
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
    }
}
