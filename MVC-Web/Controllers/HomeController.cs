using DAL;
using MVC_Web.Tags;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Controllers
{
    [NoLogin]
    public class HomeController : Controller
    {
        UsuarioServicio usuarioServicio;

        public HomeController()
        {
            ConsorcioCtx context = new ConsorcioCtx();
            usuarioServicio = new UsuarioServicio(context);
        }

        public ActionResult Inicio()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Ingreso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ingreso(Usuario usuario)
        {
            Boolean response = usuarioServicio.loguearUsuario(usuario);
            if(response == true)
            {
                return RedirectToAction("Index", "Consorcio");
            }
            return Redirect("Inicio");
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario, string pass2)
        {
            Boolean response = usuarioServicio.registrarUsuario(usuario, pass2);
             if(response == true)
            {
                return Redirect("Inicio");
            }
            else
            {
                return View("Registro");
            }
        }

        public ActionResult Salir()
        {
            usuarioServicio.desloguearUsuario();
            return Redirect("Inicio");
        }
    }
}