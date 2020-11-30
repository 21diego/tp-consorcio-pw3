using DAL;
using MVC_Web.Tags;
using Newtonsoft.Json;
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
        // GET: Expensas
        public ActionResult Index(int IdConsorcio)
        {
            var url = "https://localhost:44375/api/Expensas?idConsorcio=" + IdConsorcio;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader == null) return Redirect("Index/Inicio");
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<List<ExpensasDTO>>(responseBody);
                        ViewBag.expensasMesActual = result.First();
                        return View(result);
                    }
                }
            }
        }
    }
}