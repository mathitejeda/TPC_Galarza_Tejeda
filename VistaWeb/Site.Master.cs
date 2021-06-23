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
    public partial class SiteMaster : MasterPage
    {
        public List<ListaTicket> listado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //temporal para que no  falle
            
            listado = new List<ListaTicket>();
            listado.Add(new ListaTicket
            {
                IdTicket = 1,
                IDEstado = 1,
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

        }
    }
}