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
            AccesoDatos datos = new AccesoDatos();
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
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Usuario> listarClientes()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
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
                    aux.Id = datos.Lector.GetInt64(0);
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
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }

        public Usuario ValidarUsuario(String mail, String contrasenia) {

            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();
            try
            {
                datos.setConsulta("SELECT U.IDUsuario, U.IDTipo, U.nombre, U.apellido FROM Autenticaciones AS A " +
                        "INNER JOIN usuarios AS U ON A.IDUsuario = U.IDUsuario " +
                        "WHERE U.mail = '" + mail +
                        "' AND A.Contrasenia = '" + contrasenia + "'"
                        );
                //datos.setParametro("@email", email);
                //datos.setParametro("@password", password);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.Id = datos.Lector.GetInt64(0);
                    usuario.tipoUsuario = datos.Lector.GetInt32(1);
                    usuario.Nombre = datos.Lector.GetString(2);
                    usuario.Apellido = datos.Lector.GetString(3);                    
                    return usuario;
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                datos = null;
            }


            //try
            //{
            //    datos.setConsulta("SELECT U.IDUsuario FROM Autenticaciones AS A " +
            //        "INNER JOIN usuarios AS U ON A.IDUsuario = U.IDUsuario " +
            //        "WHERE U.mail = '" + mail + 
            //        "' AND A.Contrasenia = '" + contrasenia + "'"
            //        );
            //datos.setParametro("@MAIL", mail);
            //datos.setParametro("@CONTRASENIA", contrasenia);
            //    datos.ejecutarLectura();
            //    while (datos.Lector.Read())
            //    {
            //        result = datos.Lector.GetInt32(0);

            //    }
            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    return result;
            //    //throw ex;
            //}
            //finally
            //{
            //    datos.cerrarConexion();
            //}

        }

        public Usuario DevolverUsuario(int idUsuario)
        {            
            AccesoDatos datos = new AccesoDatos();
            Usuario result = new Usuario();
            try
            {
                
                datos.setConsulta("SELECT * FROM USUARIOS WHERE IDUsuario = @idUsuario");
                datos.setParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    result.Id = datos.Lector.GetInt64(0);
                    result.tipoUsuario = datos.Lector.GetInt32(1);
                    result.Nombre = datos.Lector.GetString(2);
                    result.Apellido = datos.Lector.GetString(3);
                    result.DNI = datos.Lector.GetString(4);
                    result.infoContacto = new Contacto(datos.Lector.GetString(5), datos.Lector.GetString(6), datos.Lector.GetString(7), datos.Lector.GetInt16(8));
                    return result;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            result.Id = 0;
            return result;
        }
    }
}


