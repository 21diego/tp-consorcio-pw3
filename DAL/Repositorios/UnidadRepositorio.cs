﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnidadRepositorio
    {
        ConsorcioCtx ctx;

        public UnidadRepositorio(ConsorcioCtx contexto)
        {
            ctx = contexto;
        }

        public  void Alta(Unidad u)
        {
            ctx.Unidads.Add(u);
            ctx.SaveChanges();
        }

        public  List<Unidad> ObtenerTodos()
        {
            return ctx.Unidads.ToList();
        }

        public Unidad ObtenerPorId(int idUnidad)
        {
            Unidad u;
            u = ctx.Unidads.Find(idUnidad);
            return u;
        }

        public void Eliminar(int idUnidad)
        {
            Unidad u = ObtenerPorId(idUnidad);
            if (u != null)
            {
                ctx.Unidads.Remove(u);
            }
            ctx.SaveChanges();
        }

        public void Modificar(Unidad u)
        {
            Unidad uniActual = ObtenerPorId(u.IdUnidad);
            uniActual.IdConsorcio = u.IdConsorcio;
            uniActual.IdUnidad = u.IdUnidad;
            uniActual.Nombre = u.Nombre;
            uniActual.NombrePropietario = u.NombrePropietario;
            uniActual.Superficie = u.Superficie;
        } 
    }
}
