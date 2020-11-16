using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return repositorio.listarConsorcios();
        }

        public void guardarConsorcio(Consorcio consorcio)
        {
            DateTime now = DateTime.Now;
            consorcio.FechaCreacion = now;
            repositorio.guardarConsorcio(consorcio);
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
    }
}