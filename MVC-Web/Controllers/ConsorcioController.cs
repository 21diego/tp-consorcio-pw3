using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Entidades.repositorios;
using Servicios;

namespace MVC_Web.Controllers
{
    public class ConsorcioController : Controller
    {
        ConsorcioServicio servicio;
        ConsorcioRepositorio repositorio;

        public ConsorcioController()
        {
            PW3_TP_20202CEntities context = new PW3_TP_20202CEntities();
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