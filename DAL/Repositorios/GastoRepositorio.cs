using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

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
            return context.Gastoes.Where(gasto => gasto.IdConsorcio == idConsorcio).ToList();
        }
        
        
        public void guardarGasto(Gasto gasto)
        {
                context.Gastoes.Add(gasto);
                context.SaveChanges();
        }

        public void eliminarGasto(Gasto gasto)
        {
            context.Gastoes.Remove(gasto); 
            context.SaveChanges();
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
