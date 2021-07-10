﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    public class servicioNegocio
    {
        public List<servicios> listar()
        {
            List<servicios> lista = new List<servicios>;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select S.IDTipo, S.Nombre from servicios as S";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    servicios aux = new servicios();
                    aux.IDTipo = datos.Lector.GetInt32(0);
                    aux.Nombre = datos.Lector.GetString(1);
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
