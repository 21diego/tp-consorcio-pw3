using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL;

namespace Servicios
{
    public class ConsorcioServicio
    {
       ConsorcioRepositorio repositorio;

        public ConsorcioServicio(ConsorcioCtx contexto)
        {
            repositorio = new DAL.ConsorcioRepositorio(contexto);
        }

        public List<Consorcio> listarConsorcios()
        {
            int idUsuario = (int)HttpContext.Current.Session["usuario"];
            return repositorio.listarConsorcios(idUsuario);
        }

        public int  guardarConsorcio(Consorcio consorcio)
        {
            DateTime now = DateTime.Now;
            consorcio.FechaCreacion = now;
            consorcio.IdUsuarioCreador = (int)HttpContext.Current.Session["usuario"];
            return repositorio.guardarConsorcio(consorcio);
        }

        public Consorcio obtenerConsorcio(int idConsorcio)
        {
            return repositorio.obtenerConsorcio(idConsorcio);
        }

        public Boolean eliminarConsorcio(int idConsorcio)
        {
            Consorcio consorcio = repositorio.obtenerConsorcio(idConsorcio);
            if (consorcio != null)
            {
                repositorio.eliminarConsorcio(consorcio);
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean editarConsorcio(Consorcio consorcio)
        {
            Consorcio consorcioObtenido = repositorio.obtenerConsorcio(consorcio.IdConsorcio);
            if (consorcioObtenido != null)
            {
                repositorio.editarConsorcio(consorcio);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int cantidadUnidadesConsorcio(Consorcio consorcio)
        {
            return repositorio.cantidadUnidadesConsorcio(consorcio);
        }
    }
}