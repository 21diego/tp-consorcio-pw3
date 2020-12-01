using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConsorcioRepositorio
    {
        ConsorcioCtx context;

        public ConsorcioRepositorio(ConsorcioCtx contexto)
        {
            context = contexto;

        }

        public List<Consorcio> listarConsorcios(int idUsuario)
        {
            return context.Consorcios.Where(c=> c.IdUsuarioCreador == idUsuario).ToList();
        }

        public int guardarConsorcio(Consorcio consorcio)
        {
            context.Consorcios.Add(consorcio);
            context.SaveChanges();
            return consorcio.IdConsorcio;
        }


        public void eliminarConsorcio(Consorcio consorcio)
        {
            context.Consorcios.Remove(consorcio);
            context.SaveChanges();
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

        public int cantidadUnidadesConsorcio(Consorcio consorcio)
        {
            return context.Unidads.Where(c => c.IdConsorcio == consorcio.IdConsorcio).Count();
        }
    }
}