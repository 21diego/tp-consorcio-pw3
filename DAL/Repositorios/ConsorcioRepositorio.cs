using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.repositorios
{
    public class ConsorcioRepositorio
    {
        ConsorcioCtx context;

        public ConsorcioRepositorio(ConsorcioCtx contexto)
        {
            context = contexto;

        }

        public List<Consorcio> listarConsorcios()
        {
            return context.Consorcios.ToList();
        }

        public void guardarConsorcio(Consorcio consorcio)
        {
            context.Consorcios.Add(consorcio);
            context.SaveChanges();
        }

        public void eliminarConsorcio(Consorcio consorcio)
        {
            context.Consorcios.Remove(consorcio);
        }

        public Consorcio obtenerConsorcio(int idConsorcio)
        {
            return context.Consorcios.Find(idConsorcio);
        }

        public void editarConsorcio(Consorcio consorcio)
        {
            Consorcio consorcioObtenido = context.Consorcios.Find(consorcio.IdConsorcio);
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