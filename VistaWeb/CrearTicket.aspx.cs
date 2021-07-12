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
        public List<Servicios> listaServicios { get; set; }
        servicioNegocio servicionegocio { get; set; }
        public List<Productos> listaProductos { get; set; }
        //Ticket nuevoTicket;
        public Usuario usuario { get; set; }
        public List<Usuario> listaUsuario { get; set; }
        public UsuarioNegocio usuarioNegocio { get; set; }
        public ProductoNegocio productoNegocio { get; set; }

        //Usuario usuarioLogeado;
        protected void Page_Load(object sender, EventArgs e)
        {
            //si no existe usuario, me voy a la pagina de login
            usuario = new Usuario();
            usuario = (Usuario)Session[Session.SessionID + "usuarioLogueado"];
            if ((Session[Session.SessionID + "usuarioLogueado"]) == null) { Response.Redirect("Login.aspx"); }

            if (!this.IsPostBack)
            {
                //lista de productos asociados al cliente
                productoNegocio = new ProductoNegocio();
                listaProductos = new List<Productos>();
                listaProductos = productoNegocio.ListarPorCliente(usuario.Id);
                ddlProducto.DataSource = listaProductos;
                ddlProducto.DataTextField = "nombre";
                ddlProducto.DataValueField = "id";
                ddlProducto.DataBind();

                ddlserie.DataSource = listaProductos;
                ddlserie.DataTextField = "nroserie";
                ddlserie.DataValueField = "nroserie";
                ddlserie.DataBind();

                servicionegocio = new servicioNegocio();
                listaServicios = new List<Servicios>();
                listaServicios = servicionegocio.listar();
                ddlServicio.DataSource = listaServicios;
                ddlServicio.DataTextField = "Nombre";
                ddlServicio.DataValueField = "IDTipo";
                ddlServicio.DataBind();
            }


            //servicioNegocio Snegocio = new servicioNegocio();
            //ProductoNegocio Pnegocio = new ProductoNegocio();
            //usuarioLogeado = new Usuario();
            //usuarioLogeado = (Usuario)Session[Session.SessionID + "usuarioLogueado"];
            //try
            //{
            //    servicios = Snegocio.listar();
            //    productos = Pnegocio.Listar();
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            ////para dropdown de tipo de servicio
            //ddlServicio.DataSource = servicios;
            //ddlServicio.DataValueField = "IDTipo";
            //ddlServicio.DataTextField = "Nombre";
            //ddlServicio.DataBind();
            ////para dropdown de tipo de negocio
            //ddlProducto.DataSource = productos;
            //ddlProducto.DataValueField = "id";
            //ddlProducto.DataTextField = "nombre";
            //ddlProducto.DataBind();
        }
        

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            //IDCliente bigint FOREIGN key references usuarios(IDUsuario) not null,
            //    FechaIngreso date not null,

            try
            {
                //ticketNegocio Tnegocio = new ticketNegocio();
                //nuevoTicket = new Ticket();
                //nuevoTicket.cliente.Id = usuarioLogeado.Id;
                //nuevoTicket.producto.id = long.Parse(ddlProducto.SelectedValue);
                //nuevoTicket.servicios.IDTipo = int.Parse(ddlServicio.SelectedValue);
                //nuevoTicket.problema = tbProblema.Text;
                //Tnegocio.crearTicket(nuevoTicket);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}