using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servicios;

namespace MVC_Web.Controllers
{
    public class ConsorcioController : Controller
    {
        private ServicioConsorcio servicioConsorcio = ServicioConsorcio.getInstance();

        // GET: Consorcio
        public ActionResult Index()
        {
            // nostrar lista consorcios
            List<Consorcio> consorcios = servicioConsorcio.listarConsorcios();

            return View(consorcios);
        }
        
        public ActionResult update(int id)
        {
            Consorcio consorcio = servicioConsorcio.getConsorcioById(id);

            return View(consorcio);
        }
    }
}