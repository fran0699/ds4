using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;



namespace Laboratorio192.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string respuestaApi = "";
            try
            {
                string urlBaseApi = "https://localhost:44387/";
                using (HttpClient clienteHttp = new HttpClient())
                {
                    clienteHttp.BaseAddress = new Uri(urlBaseApi);
                    HttpResponseMessage respuesta = clienteHttp.GetAsync("api/values/get").Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        respuestaApi = respuesta.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        int codigoEstado = (int)respuesta.StatusCode;
                        respuestaApi = "Error al llamar al API. Código: "
                                       + codigoEstado + " - " + respuesta.ReasonPhrase;
                    }
                }
            }
            catch (Exception ex)
            {
                respuestaApi = "Ocurrió una excepción al llamar al API: " + ex.Message;
            }
            ViewBag.RespuestaApi = respuestaApi;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}