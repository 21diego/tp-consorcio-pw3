using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Controllers
{
    public class UnidadController : Controller
    {
        // GET: Unidad
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Modificar()
        {
            return View();
        }
    }
}