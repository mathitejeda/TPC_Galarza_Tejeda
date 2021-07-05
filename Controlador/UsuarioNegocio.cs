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
        public List<Usuario> listarTecnicos()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos= new AccesoDatos();
            try
            {
                string consulta =
                    "select U.IDUsuario, U.nombre, U.apellido, U.DNI, U.celular, U.domicilio " +
                    "from usuarios as U " +
                    "inner join tipoUsuario as TU on U.IDTipo = TU.IDTipo " +
                    "where TU.Descripcion like 'tecnico'";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Nombre = datos.Lector.GetString(1);
                    aux.Apellido = datos.Lector.GetString(2);
                    aux.DNI = datos.Lector.GetString(3);
                    aux.infoContacto.celular = datos.Lector.GetString(4);
                    aux.infoContacto.direccion = datos.Lector.GetString(5);
                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
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
                    aux.infoContacto.celular = datos.Lector.GetString(4);
                    aux.infoContacto.direccion = datos.Lector.GetString(5);
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


