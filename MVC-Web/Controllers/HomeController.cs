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

        [NoLogin]
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

        [NoLogin]
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario, string pass2)
        {
            if (pass2.Equals(""))
            {
                return View("Registro");
            }
            TempData.Remove("mensaje");
            string response = usuarioServicio.registrarUsuario(usuario, pass2);
            if (response.Equals("Registrado con éxito"))
            {
                return Redirect("Inicio");
            }
            else
            {
                TempData.Add("mensaje", response);
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