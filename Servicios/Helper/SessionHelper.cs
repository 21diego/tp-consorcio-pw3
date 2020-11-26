using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Servicios.Helper
{
    public class SessionHelper
    {
        public static void AgregarUsuarioSession(int id)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                HttpContext.Current.Session["usuario"] = id;
            }
        }
        public static bool ExisteUsuarioEnSession()
        {
            return HttpContext.Current.Session["usuario"] != null;
        }
        public static void DestruirSession()
        {
            HttpContext.Current.Session["usuario"] = null;
        }
    }
}
