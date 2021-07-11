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
    public partial class Tecnicodetalle : System.Web.UI.Page
    {
        public int idseleccionado;
        protected Ticket ticketSeleccionado;
        public List<EstadoTicket> estados;
        protected void Page_Load(object sender, EventArgs e)
        {
            ticketNegocio Tnegocio = new ticketNegocio();
                //idseleccionado = Convert.ToInt32(Request.QueryString["id"]);
                idseleccionado = 1;
            Ticket ticketSeleccionado = Tnegocio.detalle(idseleccionado);
            EstadoNegocio Enegocio = new EstadoNegocio();
            try
            {
                estados = Enegocio.Listar(); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            tbCliente.Text = ticketSeleccionado.cliente.Nombre;
            tbProducto.Text = ticketSeleccionado.producto.nombre;
            ddlEstado.DataSource = estados;
            ddlEstado.DataTextField = "nombre";
            ddlEstado.DataValueField = "idestado";
            ddlEstado.DataBind();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}