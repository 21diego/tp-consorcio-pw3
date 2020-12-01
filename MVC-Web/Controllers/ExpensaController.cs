using DAL;
using MVC_Web.Tags;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Controllers
{
    public class ExpensaController : Controller
    {
        ConsorcioServicio ConsorcioServ;

        public ExpensaController()
        {
            ConsorcioCtx context = new ConsorcioCtx();
            ConsorcioServ = new ConsorcioServicio(context);
        }

        [Autenticado]
        // GET: Expensas
        public ActionResult Index(int idConsorcio)
        {
            SetConsorcioBreadcrumbTitle(idConsorcio);
            return View();
        }

        private void SetConsorcioBreadcrumbTitle(int Id)
        {
            var consorcio = ConsorcioServ.obtenerConsorcio(Id);
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