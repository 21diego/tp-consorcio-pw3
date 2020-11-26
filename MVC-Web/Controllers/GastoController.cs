using System;
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
    public class GastoController : Controller
    {
        GastoServicio GastoServ;
        ConsorcioServicio ConsorcioServ;

        public GastoController()
        {
            ConsorcioCtx context = new ConsorcioCtx();
            GastoServ = new GastoServicio(context);
            ConsorcioServ = new ConsorcioServicio(context);
        }
        
        // GET: Gasto/Lista/idConsorcio
        public ActionResult Lista(int? idConsorcio)
        {
            if(idConsorcio == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            List<Gasto> listaGastos = GastoServ.listarGastos((int)idConsorcio);
            //Buscar el consorcio al que pertenece el gasto segun IdConsorcio
            ViewBag.consorcio = ConsorcioServ.obtenerConsorcio((int)idConsorcio);
            return View(listaGastos);
        }

        [HttpGet]
        public ActionResult Create(int idConsorcio)
        {
            ViewBag.consorcio = ConsorcioServ.obtenerConsorcio(idConsorcio);
            ViewBag.tiposGastos = GastoServ.ObtenerTiposGastos();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Gasto gasto)
        {
            GastoServ.guardarGasto(gasto);
            return Redirect("Lista");
        }
        [HttpGet]
        public ActionResult Update(int idGasto)
        {
            Gasto gasto = GastoServ.obtenerGasto(idGasto);
            ViewBag.consorcio = ConsorcioServ.obtenerConsorcio(gasto.IdConsorcio);
            ViewBag.tiposGastos = GastoServ.ObtenerTiposGastos();
            return View(gasto);
        }
        [HttpPost]
        public ActionResult Update(Gasto gasto)
        {
            GastoServ.editarGasto(gasto);
            return Redirect("Lista");
        }
    }
}