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

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio Unegocio = new UsuarioNegocio();
            try
            {
                tecnicos = Unegocio.listarTecnicos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ddlTecnicos.DataSource = tecnicos;
            ddlTecnicos.DataTextField = "Nombre";
            ddlTecnicos.DataBind();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {

        }
    }
}