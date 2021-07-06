using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class UsuarioNegocio
    {
        public List<Usuario> ListarTecnicos()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos= new AccesoDatos();
            try
            {
                string consulta =
                    "select U.IDUsuario, U.nombre, U.apellido, U.DNI, U.domicilio, U.Telefono, U.celular, U.codigoPostal " +
                    "from usuarios as U " +
                    "inner join tipoUsuario as TU on U.IDTipo = TU.IDTipo " +
                    "where TU.Descripcion like 'tecnico'";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = datos.Lector.GetInt64(0);
                    aux.Nombre = datos.Lector.GetString(1);
                    aux.Apellido = datos.Lector.GetString(2);
                    aux.DNI = datos.Lector.GetString(3);
                    aux.infoContacto = new Contacto(datos.Lector.GetString(4), datos.Lector.GetString(5), datos.Lector.GetString(6), datos.Lector.GetInt16(7));
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public List<Usuario> listarClientes()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos= new AccesoDatos();
            try
            {
                string consulta =
                    "select U.IDUsuario, U.nombre, U.apellido, U.DNI, u.celular, u.domicilio " +
                    "from usuarios as U " +
                    "inner join tipoUsuario as TU on U.IDTipo = TU.IDTipo " +
                    "where TU.Descripcion like 'cliente'";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Nombre = datos.Lector.GetString(1);
                    aux.Apellido = datos.Lector.GetString(2);
                    aux.DNI = datos.Lector.GetString(3);
                    aux.infoContacto.Celular = datos.Lector.GetString(4);
                    aux.infoContacto.Direccion = datos.Lector.GetString(5);
                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

    }
}


