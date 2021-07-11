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
    public partial class CrearTicket : System.Web.UI.Page
    {
        List<Servicios> servicios;
        List<Productos> productos;
        Ticket nuevoTicket;

        Usuario usuarioLogeado;
        protected void Page_Load(object sender, EventArgs e)
        {
            servicioNegocio Snegocio = new servicioNegocio();
            ProductoNegocio Pnegocio = new ProductoNegocio();
            usuarioLogeado = new Usuario();
            usuarioLogeado = (Usuario)Session[Session.SessionID + "usuarioLogueado"];
            try
            {
                servicios = Snegocio.listar();
                productos = Pnegocio.Listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //para dropdown de tipo de servicio
            ddlServicio.DataSource = servicios;
            ddlServicio.DataValueField = "IDTipo";
            ddlServicio.DataTextField = "Nombre";
            ddlServicio.DataBind();
            //para dropdown de tipo de negocio
            ddlProducto.DataSource = productos;
            ddlProducto.DataValueField = "id";
            ddlProducto.DataTextField = "nombre";
            ddlProducto.DataBind();
        }
        

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                ticketNegocio Tnegocio = new ticketNegocio();
                nuevoTicket = new Ticket();
                nuevoTicket.cliente.Id = usuarioLogeado.Id;
                nuevoTicket.producto.id = long.Parse(ddlProducto.SelectedValue);
                nuevoTicket.servicios.IDTipo = int.Parse(ddlServicio.SelectedValue);
                nuevoTicket.problema = tbProblema.Text;
                Tnegocio.crearTicket(nuevoTicket);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}