﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controlador
{
    class ProductoNegocio
    {
        public List<Productos> Listar()
        {
            List<Productos> lista = new List<Productos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select p.nombre, p.descripcion, sp.NROSerie " +
                    "from productos as P " +
                    "inner join serieProducto as SP on SP.IDProducto = P.IDProducto ";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Productos aux = new Productos();
                    aux.nombre=datos.Lector.GetString(0);
                    aux.detalle = datos.Lector.GetString(1);
                    aux.numeroSerie = datos.Lector.GetInt64(2);
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