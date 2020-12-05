using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL;

namespace Servicios
{
    public class GastoServicio
    {
        DAL.Repositorios.GastoRepositorio repositorio;
        DAL.Repositorios.TipoGastoRepositorio TGRepo;
        DAL.ConsorcioRepositorio CRepo;

        public GastoServicio(ConsorcioCtx contexto)
        {
            repositorio = new DAL.Repositorios.GastoRepositorio(contexto);
            TGRepo = new DAL.Repositorios.TipoGastoRepositorio(contexto);
            CRepo = new DAL.ConsorcioRepositorio(contexto);
        }
        public List<TipoGasto> ObtenerTiposGastos()
        {
            return TGRepo.ObtenerTiposGastos();
        }
        public List<Gasto> listarGastos(int idConsorcio)
        {
            return repositorio.listarGastos(idConsorcio);
        }

        public void guardarGasto(Gasto gasto)
        {
            repositorio.guardarGasto(gasto);
        }

        public Gasto obtenerGasto(int idGasto)
        {
            return repositorio.obtenerGasto(idGasto);
        }

        public int eliminarGasto(Gasto gasto, string archivo)
        {
            if (gasto != null)
            {
                if (System.IO.File.Exists(archivo))
                {
                    System.IO.File.Delete(archivo);
                }
                repositorio.eliminarGasto(gasto);
                return gasto.IdConsorcio;
            }
            else
            {
                return 0;
            }

        }
        public void editarGasto(Gasto gasto)
        {
            repositorio.editarGasto(gasto);
        }

        public Boolean perteneceAUsuarioConectado(int idGasto)
        {
            Gasto gastoObtenido = repositorio.obtenerGasto(idGasto);
            if (gastoObtenido != null)
            {
                Consorcio consorcioObtenido = CRepo.obtenerConsorcio(gastoObtenido.IdConsorcio);
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
