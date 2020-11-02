using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public class ExpensaRepositorio
    {
        ConsorcioCtx ctx;

        public ExpensaRepositorio(ConsorcioCtx contexto)
        {
            ctx = contexto;
        }


    }
}
