using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Servicios;
using DAL;

namespace ApiConsorcioExpensas.Controllers
{
    public class ExpensasController : ApiController
    {
        ConsorcioCtx context;
        ExpensaServicio ExpensasServ;

        public ExpensasController()
        {
            context = new ConsorcioCtx();
            ExpensasServ = new ExpensaServicio(context);
        }
        [HttpGet]
        public IEnumerable<ExpensasDTO> Get(int idConsorcio)
        {

            return ExpensasServ.ObtenerExpensas(idConsorcio);
        }
    }
}