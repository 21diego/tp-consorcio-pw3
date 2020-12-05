using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using MVC_Web.Tags;
using MvcSiteMapProvider.Web.Mvc.Filters;
using Servicios;

namespace MVC_Web.Controllers
{
    [Autenticado]
    public class ConsorcioController : Controller
    {
        ConsorcioServicio servicioConsorcio;
        ProvinciaServicio servicioProvincia;

        public ConsorcioController()
        {
            ConsorcioCtx context = new ConsorcioCtx();
            servicioConsorcio = new ConsorcioServicio(context);
            servicioProvincia = new ProvinciaServicio(context);
        }

        [HttpGet]
        public ActionResult Index()
        {
            // nostrar lista consorcios
            List<Consorcio> consorcios = servicioConsorcio.listarConsorcios();

            return View("Index", consorcios);
        }

        [HttpGet]
        public ActionResult create()
        {
            List<Provincia> provincias = servicioProvincia.listarProvincias();

            ViewBag.provincias = provincias;

            return View();
        }
        [HttpPost]
        public ActionResult create(Consorcio consorcio)
        {

            servicioConsorcio.guardarConsorcio(consorcio);
            TempData["Mensaje"] = "Consorcio " + consorcio.Nombre + " creado con éxito";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CrearYOtra(Consorcio consorcio)
        {
            servicioConsorcio.guardarConsorcio(consorcio);
            TempData["Mensaje"] = "Consorcio " + consorcio.Nombre + " creado con éxito";
            return RedirectToAction("create");
        }

        public ActionResult CrearYUnidad(Consorcio consorcio)
        {
            int idConsorcio = servicioConsorcio.guardarConsorcio(consorcio);
            TempData["Mensaje"] = "Consorcio " + consorcio.Nombre + " creado con éxito";
            return RedirectToAction("Crear", "Unidad", new { @idConsorcio = idConsorcio });
        }

        [HttpGet]
        public ActionResult delete(int idConsorcio)
        {
            if (servicioConsorcio.perteneceAUsuarioConectado(idConsorcio) == false)
            {
                return RedirectToAction("Index");
            }

            servicioConsorcio.eliminarConsorcio(idConsorcio);
            TempData["Mensaje"] = "Consorcio eliminado con éxito";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [SiteMapTitle("title")]
        public ActionResult update(int idConsorcio)
        {
            if (servicioConsorcio.perteneceAUsuarioConectado(idConsorcio) == false)
            {
                return RedirectToAction("Index");
            }
            Consorcio consorcio = servicioConsorcio.obtenerConsorcio(idConsorcio);
            List<Provincia> provincias = servicioProvincia.listarProvincias();
            int cantidadUnidades = servicioConsorcio.cantidadUnidadesConsorcio(consorcio);

            ViewBag.provincias = provincias;
            ViewBag.cantidadUnidades = cantidadUnidades;

            ViewData["Title"] = "Consorcio \"" + consorcio.Nombre +"\"";

            return View(consorcio);
        }

        [HttpPost]
        public ActionResult update(Consorcio consorcio)
        {
            servicioConsorcio.editarConsorcio(consorcio);
            TempData["Mensaje"] = "Consorcio " + consorcio.Nombre + " modificado con éxito";

            return RedirectToAction("Index");
        }
    }
}