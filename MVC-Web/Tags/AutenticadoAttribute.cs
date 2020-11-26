using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Servicios.Helper;

namespace MVC_Web.Tags
{
    class AutenticadoAttribute : ActionFilterAttribute
    {
        SessionHelper sessionHelper;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!SessionHelper.ExisteUsuarioEnSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Inicio"
                }));
            }
        }
    }
    public class NoLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (SessionHelper.ExisteUsuarioEnSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Consorcio",
                    action = "Index"
                }));
            }
        }
    }
}
