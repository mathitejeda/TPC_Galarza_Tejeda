using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Controlador;

namespace VistaWeb
{
    public partial class Default : Page
    {
        public List<Ticket> Listado { get; set; }
        public Usuario usuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session[Session.SessionID + "usuario"];
            ticketNegocio negocio = new ticketNegocio();
            /*
            Listado = new List<ListaTicket>();
            Listado.Add(new ListaTicket
            {
                IdTicket = 1,
                IDEstado = 1,
                IdCliente = 1,
                IdTecnico = 1,
                IdProducto = 1,
                Estado = "Aprobado",
                Cliente = "Cliente",
                Tecnico = "Tecnico",
                FechaIngreso = DateTime.Now,
                Producto = "Producto"
            });
            */
            //listado = (List<ListaTicket>)Session[Session.SessionID + "listado"];
            try
            {
                Listado = negocio.listar();
            }
            catch (Exception ex)
            {
                //TODO: Agregar una pantalla de error para poder redireccionar
                throw ex;
            }
            repeater.DataSource = Listado;
        }
    }
}