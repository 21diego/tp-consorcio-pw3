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


        public ActionResult Lista(int idConsorcio)
        {
            ViewBag.IdConsorcio = idConsorcio;

            List<Unidad> unidades = uniServi.ObtenerTodosPorId(idConsorcio);

            SetConsorcioBreadcrumbTitle(idConsorcio);
            return View(unidades);
        }

        public ActionResult Crear(int idConsorcio)
        {
            ViewBag.IdConsorcio = idConsorcio;
            
            var consorcio = consorServi.obtenerConsorcio(idConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;

            ViewBag.FechaCreacion = DateTime.Now.ToString();

            SetConsorcioBreadcrumbTitle(idConsorcio);

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Unidad u, int idConsorcio)
        {
            ViewBag.IdConsorcio = idConsorcio;
            var consorcio = consorServi.obtenerConsorcio(idConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;
            ViewBag.FechaCreacion = DateTime.Now.ToString();

            if (!ModelState.IsValid)
            {
                SetConsorcioBreadcrumbTitle(idConsorcio);
                return View();
                //return Redirect("/Unidad/Crear/" + u.IdConsorcio);
            }
            uniServi.Crear(u);
            return Redirect("/Unidad/Lista/" + idConsorcio);
            
        }

        [HttpPost]
        public ActionResult CrearYOtra(Unidad u, int idConsorcio)
        {
            ViewBag.IdConsorcio = idConsorcio;
            var consorcio = consorServi.obtenerConsorcio(idConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;
            ViewBag.FechaCreacion = DateTime.Now.ToString();

            if (!ModelState.IsValid)
            {
                SetConsorcioBreadcrumbTitle(idConsorcio);
                return View("Crear");
                //return Redirect("/Unidad/Crear/" + Id);
            }
            TempData["SuccessMsg"] = "Unidad " + u.Nombre + " creada con éxito";
            uniServi.Crear(u);
            return Redirect("/Unidad/Crear/" + idConsorcio);

        }

        public ActionResult Modificar(int idConsorcio, int idUnidad)
        {
            Unidad u = uniServi.ObtenerPorId(idUnidad);
            var consorcio = consorServi.obtenerConsorcio(idConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;

            SetConsorcioBreadcrumbTitle(u.IdConsorcio);

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

            return Redirect("/unidad/lista/"+u.IdConsorcio);
        }

        public ActionResult Eliminar(int idConsorcio, int idUnidad)
        {
            Unidad u = uniServi.ObtenerPorId(idUnidad);

            ViewBag.IdConsorcio = u.IdConsorcio;
            var consorcio = consorServi.obtenerConsorcio(u.IdConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;  

            SetConsorcioBreadcrumbTitle(u.IdConsorcio);

            return View(u);
        }

        [HttpPost]
        public ActionResult Eliminar(Unidad u)
        {
            int IdConsorcio = u.IdConsorcio;
            uniServi.Eliminar(u.IdUnidad);
            return Redirect("/Unidad/Lista/"+IdConsorcio);
        }

        private void SetConsorcioBreadcrumbTitle(int idConsorcio)
        {
            var consorcio = consorServi.obtenerConsorcio(idConsorcio);
            string NombreConsorcio = consorcio.Nombre;
            var node = SiteMaps.Current.CurrentNode;
            FindParentNode(node, "ConsorcioX", $"Consorcio \"{NombreConsorcio}\"");
        }

        private static void FindParentNode(ISiteMapNode node, string oldTitle, string newTitle)
        {
            if (node.Title == oldTitle)
            {
                node.Title = newTitle;
            }
            else
            {
                if (node.ParentNode != null)
                {
                    FindParentNode(node.ParentNode, oldTitle, newTitle);
                }
            }
        }
    }
}