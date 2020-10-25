using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Controllers
{
    public class ExpensaController : Controller
    {
        // GET: Expensas
        public ActionResult Index()
        {
            return View();
        }
    }
}