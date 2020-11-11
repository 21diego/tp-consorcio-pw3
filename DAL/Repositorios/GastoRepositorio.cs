using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public class GastoRepositorio
    {
        ConsorcioCtx context;

        public GastoRepositorio(ConsorcioCtx contexto)
        {
            context = contexto;

        }

        public List<Gasto> listarGastos(int idConsorcio)
        {
            return context.Gastoes.ToList();
        }

        public void guardarGasto(Gasto gasto)
        {
            context.Gastoes.Add(gasto);
            context.SaveChanges();
        }

        public void eliminarGasto(Gasto gasto)
        {
            context.Gastoes.Remove(gasto);
        }

        public Gasto obtenerGasto(int idGasto)
        {
            return context.Gastoes.Find(idGasto);
        }

        public void editarGasto(Gasto gasto)
        {
           
        }
    }
}
