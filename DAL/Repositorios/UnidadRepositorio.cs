using System;
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

        public  void Crear(Unidad u)
        {
            ctx.Unidads.Add(u);
            ctx.SaveChanges();
        }

        public  List<Unidad> ObtenerTodos()
        {
            return ctx.Unidads.ToList();
        }

        public Unidad ObtenerPorId(int IdUnidad)
        {
            Unidad u;
            u = ctx.Unidads.Find(IdUnidad);
            return u;
        }

        public List<Unidad> ObtenerTodosPorId(int IdConsorcio)
        {
            var unidades = (from u in ctx.Unidads
                            where u.IdConsorcio == IdConsorcio
                            select u).ToList();

            return unidades;
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
