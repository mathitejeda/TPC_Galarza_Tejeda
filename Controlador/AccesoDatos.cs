﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Controlador
{
    public class AccesoDatos
    {
        public SqlConnection conexion { get; set; }
        public SqlCommand comando{ get; set; }
        public SqlDataReader lector { get; set; }

        public AccesoDatos()
        {
            conexion = new SqlConnection("data source = .\\SQLEXPRESS; initial catalog = DB_TPC; integrated security = sspi;");
            comando = new SqlCommand();
        }
        public void setConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void setParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        internal void ejecutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }
    }
}
