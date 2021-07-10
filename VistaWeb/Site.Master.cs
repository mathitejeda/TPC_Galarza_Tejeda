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
    public partial class SiteMaster : MasterPage
    {
        public List<ListaTicket> listado { get; set; }
        public Usuario usuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Saco el nombre del usuario
            usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "usuarioLogueado"];
            if ((Session[Session.SessionID + "usuarioLogueado"]) != null) { lbNombreUsuarioMenu.Text = usuario.Nombre; }

            //temporal para que no  falle

            //listado = new List<ListaTicket>();
            //listado.Add(new ListaTicket
            //{
            //    IdTicket = 1,
            //    IDEstado = 1,
            //    IdCliente = 1,
            //    IdTecnico = 1,
            //    IdProducto = 1,
            //    Estado = "Aprobado",
            //    Cliente = "Cliente",
            //    Tecnico = "Tecnico",
            //    FechaIngreso = DateTime.Now,
            //    Producto = "Producto"
            //});

            //Session[Session.SessionID + "listado"] = listado;

        }
    }
}