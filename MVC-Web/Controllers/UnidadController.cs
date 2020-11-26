﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using MVC_Web.Tags;
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
<<<<<<< HEAD
        public ActionResult Lista(int idConsorcio)
=======
        public ActionResult Lista(int Id)
>>>>>>> remotes/origin/expensa2
        {
            ViewBag.IdConsorcio = Id;

            List<Unidad> unidades = uniServi.ObtenerTodosPorId(Id);
            return View(unidades);
        }

        public ActionResult Crear(int Id)
        {
<<<<<<< HEAD
            Console.WriteLine("hol");
=======

            ViewBag.IdConsorcio = Id;
            
            var consorcio = consorServi.obtenerConsorcio(Id);
            ViewBag.NombreConsorcio = consorcio.Nombre;

            ViewBag.FechaCreacion = DateTime.Now.ToString();

>>>>>>> remotes/origin/expensa2
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Unidad u, int Id)
        {
            ViewBag.IdConsorcio = u.IdConsorcio;
            var consorcio = consorServi.obtenerConsorcio(u.IdConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;
            ViewBag.FechaCreacion = DateTime.Now.ToString();

            if (!ModelState.IsValid)
            {
                return View();
                //return Redirect("/Unidad/Crear/" + u.IdConsorcio);
            }
            uniServi.Crear(u);
            return Redirect("/Unidad/Lista/" + u.IdConsorcio);
            
        }

        [HttpPost]
        public ActionResult CrearYOtra(Unidad u, int Id)
        {
            ViewBag.IdConsorcio = u.IdConsorcio;
            var consorcio = consorServi.obtenerConsorcio(u.IdConsorcio);
            ViewBag.NombreConsorcio = consorcio.Nombre;
            ViewBag.FechaCreacion = DateTime.Now.ToString();

            if (!ModelState.IsValid)
            {
                return View("Crear");
                //return Redirect("/Unidad/Crear/" + Id);
            }
            TempData["SuccessMsg"] = "Unidad " + u.Nombre + " creada con éxito";
            uniServi.Crear(u);
            return Redirect("/Unidad/Crear/" + Id);

        }

        public ActionResult Modificar(int Id, int IdUnidad)
        {
            var consorcio = consorServi.obtenerConsorcio(Id);
            ViewBag.NombreConsorcio = consorcio.Nombre;

            Unidad u = uniServi.ObtenerPorId(IdUnidad);

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