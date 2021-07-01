using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {

        int Id { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string DNI { get; set; }
        Contacto Contacto { get; set; }
        int tipoUsuario { get; set; }

        public Usuario(string nombre)
        {
            Nombre = nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
