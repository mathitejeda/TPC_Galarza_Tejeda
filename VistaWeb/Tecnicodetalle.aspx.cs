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
        public Ticket TicketSeleccionado { get; set; }
        public List<EstadoTicket> estados;
        public ticketNegocio Tnegocio = new ticketNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
                //idseleccionado = Convert.ToInt32(Request.QueryString["id"]);
            //    idseleccionado = 1;
            //TicketSeleccionado = Tnegocio.detalle(idseleccionado);
            //EstadoNegocio Enegocio = new EstadoNegocio();
            try
            {
                //estados = Enegocio.Listar(); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //tbCliente.Text = TicketSeleccionado.cliente.Nombre;
            //tbProducto.Text = TicketSeleccionado.producto.nombre;
            //tbObservaciones.Text = TicketSeleccionado.problema;
            //ddlEstado.DataSource = estados;
            //ddlEstado.DataTextField = "nombre";
            //ddlEstado.DataValueField = "idestado";
            //ddlEstado.DataBind();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
            //TicketSeleccionado.detalle = tbDiagnostico.Text;
            //TicketSeleccionado.solucion = tbSolucion.Text;
            //TicketSeleccionado.Estado.IDEstado = int.Parse(ddlEstado.SelectedValue);
            //Tnegocio.actualizarTicketTecnico(TicketSeleccionado);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}