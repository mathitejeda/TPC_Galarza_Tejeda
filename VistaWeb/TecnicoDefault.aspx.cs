using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controlador;
using VistaWeb;
using Modelo;

namespace VistaWeb
{
    public partial class TecnicoDefault : System.Web.UI.Page
            {
        public List<ListaTicket> listado { get; set; }
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //si no existe usuario, me voy a la pagina de login
            usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "usuarioLogueado"];
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) { Response.Redirect("Login.aspx"); }


            listado = new List<ListaTicket>();
            listado.Add(new ListaTicket
            {
                IdTicket = 1,
                IDEstado = 1,
                IdCliente = 1,
                IdProducto = 1,
                Estado = "Aprobado",
                Cliente = "Cliente",
                FechaIngreso = DateTime.Now,
                Producto = "Producto"

            });
        }
    }
}