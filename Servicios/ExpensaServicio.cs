using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Servicios
{
    public class ExpensaServicio
    {
        ExpensaRepositorio ExpensaRepo;
     
        public ExpensaServicio(ConsorcioCtx context)
        {
            ExpensaRepo = new ExpensaRepositorio(context);
        }

        public List<ExpensasDTO> ObtenerExpensas(int idConsorcio)
        {
            return ExpensaRepo.ObtenerExpensas(idConsorcio);
        }
    }
}
