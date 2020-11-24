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
        ConsorcioServicio consorServi;

        public UnidadController()
        {
            ConsorcioCtx ctx = new ConsorcioCtx();
            uniServi = new UnidadServicio(ctx);
            consorServi = new ConsorcioServicio(ctx);
        }
        public ActionResult Lista(int Id)
        {
            ViewBag.IdConsorcio = Id;

            List<Unidad> unidades = uniServi.ObtenerTodosPorId(Id);
            return View(unidades);
        }

        public ActionResult Crear(int Id)
        {

            ViewBag.IdConsorcio = Id;
            
            var consorcio = consorServi.obtenerConsorcio(Id);
            ViewBag.NombreConsorcio = consorcio.Nombre;

            ViewBag.FechaCreacion = DateTime.Now.ToString();

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Unidad u)
        {
            if (!ModelState.IsValid)
            {
                return View();
                //return Redirect("/Unidad/Crear/" + u.IdConsorcio);
            }

            //if (idConsorcio != null)
            //{
            //    uniServi.Crear(u);
            //    return Redirect("/unidad/lista/" + u.IdConsorcio);
            //}

            uniServi.Crear(u);
            return Redirect("/Unidad/Lista/" + u.IdConsorcio);
            
        }

        public ActionResult Modificar(int Id, int IdUnidad)
        {
            var consorcio = consorServi.obtenerConsorcio(Id);
            ViewBag.NombreConsorcio = consorcio.Nombre;

            Unidad u = uniServi.ObtenerPorId(IdUnidad);

            if (u == null)
            {
                TempData["Message"] = "El producto elegido no existe";
                return Redirect("/unidad/lista/"+Id);
            }
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

            return Redirect("/unidad/lista"+u.IdConsorcio);
        }

        public ActionResult Eliminar(int Id, int IdUnidad)
        {
            ViewBag.IdConsorcio = Id;

            var consorcio = consorServi.obtenerConsorcio(Id);
            ViewBag.NombreConsorcio = consorcio.Nombre;

            Unidad u = uniServi.ObtenerPorId(IdUnidad);
            return View(u);
        }

        [HttpPost]
        public ActionResult Eliminar(Unidad u)
        {
            int IdConsorcio = u.IdConsorcio;
            uniServi.Eliminar(u.IdUnidad);
            return Redirect("/Unidad/Lista/"+IdConsorcio);
        }
    }
}