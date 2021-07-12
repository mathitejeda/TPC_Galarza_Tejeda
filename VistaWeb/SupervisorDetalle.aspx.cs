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
    public partial class SupervisorDetalle : System.Web.UI.Page
    {
        public List<Usuario> tecnicos;
        public int IDSeleccionado;
        public Usuario usuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //si no existe usuario, me voy a la pagina de login
            usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "usuarioLogueado"];
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) { Response.Redirect("Login.aspx"); }

            UsuarioNegocio Unegocio = new UsuarioNegocio();
            IDSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            ticketNegocio Tnegocio = new ticketNegocio();
            Ticket ticketSeleccionado = Tnegocio.detalle(IDSeleccionado);
            try
            {
                tecnicos = Unegocio.ListarTecnicos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ddlTecnicos.DataSource = tecnicos;
            ddlTecnicos.DataTextField = "Apellido";
            ddlTecnicos.DataValueField = "Id";
            ddlTecnicos.DataBind();
            TextBoxCliente.Text = ticketSeleccionado.cliente.Nombre;
            TextBoxproducto.Text = ticketSeleccionado.producto.nombre;
            TextBoxObservaciones.Text = ticketSeleccionado.detalle;


        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {

        }
    }
}