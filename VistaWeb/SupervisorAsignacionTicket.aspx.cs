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
    public partial class SupervisorAsignacionTicket : System.Web.UI.Page
    {
        public List<Ticket> Listado { get; set; }
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //si no existe usuario, me voy a la pagina de login
            usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "usuarioLogueado"];
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) { Response.Redirect("Login.aspx"); }
                        
            ticketNegocio negocio = new ticketNegocio();

            try
            {
                Listado = negocio.listar();
            }
            catch (Exception ex)
            {
                //TODO: Agregar una pantalla de error para poder redireccionar
                throw ex;
            }
            repeaterSupervisor.DataSource = Listado;
            repeaterSupervisor.DataBind();
        }
    }
}