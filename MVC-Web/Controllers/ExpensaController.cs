using MVC_Web.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Controllers
{
    [Autenticado]
    public class ExpensaController : Controller
    {
        // GET: Expensas
        public ActionResult Index()
        {
            return View();
        }
    }
}