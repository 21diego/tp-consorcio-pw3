using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class UnidadServicio
    {
        UnidadRepositorio repo;
        public UnidadServicio(ConsorcioCtx contexto)
        {
            ConsorcioCtx ctx = contexto;
            repo = new DAL.UnidadRepositorio(ctx);
        }

        public void Alta(Unidad u)
        {
            repo.Alta(u);
        }

        public List<Unidad> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public Unidad ObtenerPorId(int idUnidad)
        {
            return repo.ObtenerPorId(idUnidad);
        }

        public void  Eliminar(int idUnidad)
        {
            repo.Eliminar(idUnidad);
        }

        public void Modificar(Unidad u)
        {
            repo.Modificar(u);
        }
    }
}
