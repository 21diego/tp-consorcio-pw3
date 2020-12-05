using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using MVC_Web.Tags;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;
using Servicios;

namespace MVC_Web.Controllers
{
    [Autenticado]
    public class UnidadController : Controller
    {
        UnidadServicio uniServi;
        ConsorcioServicio consorServi;

        public UnidadController()
        {
            ConsorcioCtx ctx = new ConsorcioCtx();
            uniServi = new UnidadServicio(ctx);
            consorServi = new ConsorcioServicio(ctx);
            
        }

        Breadcrumb bc = new Breadcrumb();

        public ActionResult Lista(int idConsorcio)
        {
            if (consorServi.perteneceAUsuarioConectado(idConsorcio) == false)
            {
                return RedirectToAction("Index", "Consorcio");
            }

            ViewBag.IdConsorcio = idConsorcio;

            List<Unidad> unidades = uniServi.ObtenerTodosPorId(idConsorcio);

            bc.SetConsorcioBreadcrumbTitle(idConsorcio, consorServi);
            return View(unidades);
        }

        public ActionResult Crear(int idConsorcio)
        {
            if (consorServi.perteneceAUsuarioConectado(idConsorcio) == false)
            {
                return RedirectToAction("Index", "Consorcio");
            }
            ViewBag.IdConsorcio = idConsorcio;
            
            var consorcio = consorServi.obtenerConsorcio(idConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;

            ViewBag.FechaCreacion = DateTime.Now.ToString();

            bc.SetConsorcioBreadcrumbTitle(idConsorcio, consorServi);

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Unidad u, int idConsorcio)
        {
            ViewBag.IdConsorcio = idConsorcio;
            var consorcio = consorServi.obtenerConsorcio(idConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;
            u.FechaCreacion = DateTime.Now;
            u.IdUsuarioCreador = Servicios.Helper.SessionHelper.ObtenerUsuarioEnSesion();

            if (!ModelState.IsValid)
            {
                bc.SetConsorcioBreadcrumbTitle(idConsorcio, consorServi);
                return View();
                //return Redirect("/Unidad/Crear/" + u.IdConsorcio);
            }
            TempData["Mensaje"] = "Unidad " + u.Nombre + " creada con éxito";
            uniServi.Crear(u);
            return Redirect("/Unidad/Lista/" + idConsorcio);
            
        }

        [HttpPost]
        public ActionResult CrearYOtra(Unidad u, int idConsorcio)
        {
            ViewBag.IdConsorcio = idConsorcio;
            var consorcio = consorServi.obtenerConsorcio(idConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;

            u.FechaCreacion = DateTime.Now;
            u.IdUsuarioCreador = Servicios.Helper.SessionHelper.ObtenerUsuarioEnSesion();

            if (!ModelState.IsValid)
            {
                bc.SetConsorcioBreadcrumbTitle(idConsorcio,consorServi);
                return View("Crear");
                //return Redirect("/Unidad/Crear/" + Id);
            }
            TempData["Mensaje"] = "Unidad " + u.Nombre + " creada con éxito";
            uniServi.Crear(u);
            return Redirect("/Unidad/Crear/" + idConsorcio);

        }

        public ActionResult Modificar(int idConsorcio, int idUnidad)
        {
            if (uniServi.perteneceAUsuarioConectado(idUnidad) == false)
            {
                return RedirectToAction("Index", "Consorcio");
            }
            Unidad u = uniServi.ObtenerPorId(idUnidad);
            var consorcio = consorServi.obtenerConsorcio(idConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;

            bc.SetConsorcioBreadcrumbTitle(u.IdConsorcio, consorServi);

            return View(u);
        }

        [HttpPost]
        public ActionResult Modificar(Unidad u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }
            
            uniServi.Modificar(u);
            TempData["Mensaje"] = "Unidad " + u.Nombre + " modificada con éxito";
            return Redirect("/unidad/lista/"+u.IdConsorcio);
        }

        public ActionResult Eliminar(int idConsorcio, int idUnidad)
        {
            if (uniServi.perteneceAUsuarioConectado(idUnidad) == false)
            {
                return RedirectToAction("Index", "Consorcio");
            }
            Unidad u = uniServi.ObtenerPorId(idUnidad);

            ViewBag.IdConsorcio = u.IdConsorcio;
            var consorcio = consorServi.obtenerConsorcio(u.IdConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;
      
            bc.SetConsorcioBreadcrumbTitle(u.IdConsorcio, consorServi);

            return View(u);
        }

        [HttpPost]
        public ActionResult Eliminar(Unidad u)
        {
            int IdConsorcio = u.IdConsorcio;
            TempData["Mensaje"] = "Unidad " + u.Nombre + " eliminada con éxito";
            uniServi.Eliminar(u.IdUnidad);
            return Redirect("/Unidad/Lista/"+IdConsorcio);
        }
    }
}