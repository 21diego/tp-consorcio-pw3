using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.repositorios
{
    public class ConsorcioRepositorio
    {
        PW3_TP_20202CEntities context;

        public ConsorcioRepositorio(PW3_TP_20202CEntities contexto)
        {
            context = contexto;

        }

        public List<Consorcio> listarConsorcios()
        {
            return context.Consorcio.ToList();
        }

        public void guardarConsorcio(Consorcio consorcio)
        {
            context.Consorcio.Add(consorcio);
            context.SaveChanges();
        }

        public void eliminarConsorcio(Consorcio consorcio)
        {
            context.Consorcio.Remove(consorcio);
        }

        public Consorcio obtenerConsorcio(int idConsorcio)
        {
            return context.Consorcio.Find(idConsorcio);
        }

        public void editarConsorcio(Consorcio consorcio)
        {
            Consorcio consorcioObtenido = context.Consorcio.Find(consorcio.IdConsorcio);
            consorcioObtenido.Nombre = consorcio.Nombre;
            consorcioObtenido.IdProvincia = consorcio.IdProvincia;
            consorcioObtenido.Ciudad = consorcio.Ciudad;
            consorcioObtenido.Calle = consorcio.Calle;
            consorcioObtenido.Altura = consorcio.Altura;
            consorcioObtenido.DiaVencimientoExpensas = consorcio.DiaVencimientoExpensas;

            context.SaveChanges();
        }
    }
}
