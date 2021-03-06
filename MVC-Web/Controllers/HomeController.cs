﻿using DAL;
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
    
    public class HomeController : Controller
    {
        UsuarioServicio usuarioServicio;

        public HomeController()
        {
            ConsorcioCtx context = new ConsorcioCtx();
            usuarioServicio = new UsuarioServicio(context);
        }
        [NoLogin]
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
            if(response.Equals("El email ya esta en uso"))
            {
                TempData.Add("mensajeMail", response);
                return View("Registro");
            }
            else
            {
                TempData.Add("mensajePass", response);
                return View("Registro");
            }

        }

        public ActionResult Salir()
        {
            usuarioServicio.desloguearUsuario();
            return Redirect("Inicio");
        }



        [SiteMapTitle("title")]
        public ActionResult EditarConsorcio(int id)
        {
            ViewData["Title"] = "Consorcio \"Villanova\"";
            return View();
        }     
    }
}