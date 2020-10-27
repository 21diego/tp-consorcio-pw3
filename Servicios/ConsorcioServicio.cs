using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Servicios
{
    public class ConsorcioServicio
    {
        Entidades.repositorios.ConsorcioRepositorio repositorio;

        public ConsorcioServicio(PW3_TP_20202CEntities contexto)
        {
            repositorio = new Entidades.repositorios.ConsorcioRepositorio(contexto);
        }

        public List<Consorcio> listarConsorcios()
        {
            return repositorio.listarConsorcios();
        }

        public void guardarConsorcio(Consorcio consorcio)
        {
            repositorio.guardarConsorcio(consorcio);
        }

        public Consorcio obtenerConsorcio(int idConsorcio)
        {
            return repositorio.obtenerConsorcio(idConsorcio);
        }

        public Boolean eliminarConsorcio(int idConsorcio)
        {
            Consorcio consorcio = repositorio.obtenerConsorcio(idConsorcio);
            if(consorcio != null)
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
            if(consorcioObtenido != null)
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
