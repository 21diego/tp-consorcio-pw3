using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ExpensaRepositorio
    {
        ConsorcioCtx context;
        public ExpensaRepositorio(ConsorcioCtx ctx)
        {
            context = ctx;
        }

        public List<ExpensasDTO> ObtenerExpensas(int idConsorcio)
        {
            return context.Database.SqlQuery<ExpensasDTO>(
                "GetExpensasDeConsorcio @consorcio", new SqlParameter("@consorcio", idConsorcio)
                ).ToList();
        }
    }
}
