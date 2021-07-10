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
        public int idUsuario { get; set; }
        public UsuarioNegocio usuarioNegocio { get; set; }
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //Validar usuario
            usuarioNegocio = new UsuarioNegocio();
            usuario = usuarioNegocio.ValidarUsuario(tbEmail.Text, tbPassword.Text);


            if(usuario.Id!=0)
            {
                //usuario = new Usuario();
                //usuarioNegocio = new UsuarioNegocio();
                //usuario = usuarioNegocio.DevolverUsuario(idUsuario);
                Session[Session.SessionID + "usuarioLogueado"] = usuario;
                switch (usuario.tipoUsuario)
                {
                    case 4:
                        Response.Redirect("Default.aspx");
                        break;
                    case 3:
                        Response.Redirect("TecnicoDefault.aspx");
                        break;
                    case 2:
                        Response.Redirect("SupervisorAsignacionTicket.aspx");
                        break;
                    default:
                        break;
                }
                confirmacionEstado.CssClass = "text-success";
                confirmacionEstado.Text = "usuario Validado correctamente";
            }
            else
            {
                confirmacionEstado.CssClass = "text-danger";
                confirmacionEstado.Text = "usuario NO Validado";
            }


            //si el usuario y contraseña se valida

            //colocar en session el usuario

            //dirigirse a Default.aspx

            //si no se valida

            //confirmacionEstado.CssClass = "text-danger";
            //confirmacionEstado.Text = "usuario NO Validado";

        }
    }
}