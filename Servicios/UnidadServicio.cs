using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Servicios
{
    public class UnidadServicio
    {
        UnidadRepositorio repo;
        ConsorcioRepositorio CRepo;
        public UnidadServicio(ConsorcioCtx contexto)
        {
            ConsorcioCtx ctx = contexto;
            repo = new DAL.UnidadRepositorio(ctx);
            CRepo = new DAL.ConsorcioRepositorio(ctx);
        }

        public void Crear(Unidad u)
        {
            repo.Crear(u);
        }

        public List<Unidad> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }

        public List<Unidad> ObtenerTodosPorId(int IdConsorcio)
        {
            return repo.ObtenerTodosPorId(IdConsorcio); ;
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

        public Boolean perteneceAUsuarioConectado(int idUnidad)
        {
            Unidad unidadObtenida = repo.ObtenerPorId(idUnidad);
            if (unidadObtenida != null)
            {
                Consorcio consorcioObtenido = CRepo.obtenerConsorcio(unidadObtenida.IdConsorcio);
                int idUsuario = (int)HttpContext.Current.Session["usuario"];
                if (consorcioObtenido.IdUsuarioCreador == idUsuario)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
