using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Servicios;

namespace MVC_Web.Controllers
{
    public class ConsorcioController : Controller
    {
        ConsorcioServicio servicio;

        public ConsorcioController()
        {
            ConsorcioCtx context = new ConsorcioCtx();
            servicio = new ConsorcioServicio(context);
        }

        // GET: Consorcio
        public ActionResult Index()
        {
            // nostrar lista consorcios
            List<Consorcio> consorcios = servicio.listarConsorcios();

            return View(consorcios);
        }

        public ActionResult update(int id)
        {

            return View();
        }
    }
}