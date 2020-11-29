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
            /*try
            {*/
                context.Gastoes.Add(gasto);
                context.SaveChanges();
            /*}
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }


            }*/

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
