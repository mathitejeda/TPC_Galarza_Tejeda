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
        protected void Page_Load(object sender, EventArgs e)
        {
            servicioNegocio Snegocio = new servicioNegocio();
            ProductoNegocio Pnegocio = new ProductoNegocio();
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

        }
    }
}