using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Servicios;

namespace MVC_Web.Controllers
{
    public class UnidadController : Controller
    {
        UnidadServicio uniServi;

        public UnidadController()
        {
            ConsorcioCtx ctx = new ConsorcioCtx();
            uniServi = new UnidadServicio(ctx);
        }
        public ActionResult Lista(int idConsorcio)
        {
            List<Unidad> unidades = uniServi.ObtenerTodos();
            return View(unidades);
        }

        public ActionResult Crear()
        {
            Console.WriteLine("hol");
            return View();
        }

        public ActionResult Modificar()
        {
            return View();
        }
    }
}