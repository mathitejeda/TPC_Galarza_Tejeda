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
    public partial class Login : System.Web.UI.Page
    {
        public List<ListaTicket> listado { get; set; }
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //Validar usuario

            //si el usuario y contraseña se valida

            //colocar en session el usuario
            Session[Session.SessionID + "usuario"] = usuario;

            listado = new List<ListaTicket>();
            listado.Add(new ListaTicket {IdTicket = 1, IDEstado = 1,
                IdCliente = 1,
                IdTecnico = 1,
                IdProducto = 1,
                Estado = "Aprobado",
                Cliente = "Cliente",
                Tecnico = "Tecnico",
                FechaIngreso = DateTime.Now,
                Producto = "Producto"
            }); 
            
        Session[Session.SessionID + "listado"] = listado;
            //dirigirse a Default.aspx

            //si no se valida

            //confirmacionEstado.CssClass = "text-danger";
            //confirmacionEstado.Text = "usuario NO Validado";

        }
    }
}