using DAL;
using MvcSiteMapProvider;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Web
{
    public class Breadcrumb
    {
        public int IdConsorcio { get; set; }
        
        public void SetConsorcioBreadcrumbTitle(int idConsorcio, ConsorcioServicio consorServi)
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