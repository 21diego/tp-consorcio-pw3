using DAL;
using MVC_Web.Tags;
using Newtonsoft.Json;
using Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Controllers
{
    [Autenticado]
    public class ExpensasController : Controller
    {
        ConsorcioServicio ConsorcioServ;
        Breadcrumb bc = new Breadcrumb();

        public ExpensasController()
        {
            ConsorcioCtx context = new ConsorcioCtx();
            ConsorcioServ = new ConsorcioServicio(context);
        }

        // GET: Expensas
        public ActionResult Index(int IdConsorcio)
        {
            if (ConsorcioServ.perteneceAUsuarioConectado(IdConsorcio) == false)
            {
                return RedirectToAction("Index", "Consorcio");
            }
            var url = "https://localhost:44375/api/Expensas?idConsorcio=" + IdConsorcio;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            bc.SetConsorcioBreadcrumbTitle(IdConsorcio, ConsorcioServ);
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return Redirect("Index/Inicio");
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<List<ExpensasDTO>>(responseBody);
                        if(result.Count == 0)
                        {
                            TempData["Mensaje"] = "No hay expensas disponibles";
                            TempData["ErrorMsg"] = "1";
                            return RedirectToAction("Index","Consorcio");
                        }
                        
                        ViewBag.expensasMesActual = result.First();
                        return View(result);
                    }
                }
            }
        }
    }
}