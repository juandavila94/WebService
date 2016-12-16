using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text.RegularExpressions;



namespace MVC.Controllers
{
    public class PaqueteController : Controller
    {
        //private IPaquete _paquete;
        //public HomeController(IPaquete _paquete) {
        //}
        public ActionResult Insertar(Paquete pac)
        {
             
            ServiceReference1.WebService1SoapClient cliente = new ServiceReference1.WebService1SoapClient();
            var paquetes = cliente.InsertarPaqueteAsync(pac.destinatario, pac.remitente, pac.tipo, pac.cantidad, pac.estado);
            return View();
         

        }

        public ActionResult Modificar(Paquete pac)
        {

            ServiceReference1.WebService1SoapClient cliente = new ServiceReference1.WebService1SoapClient();
            var paquetes = cliente.ModificarPaqueteAsync(pac.id,pac.destinatario, pac.remitente, pac.tipo, pac.cantidad, pac.estado);
            return View();


        }


        public ActionResult Eliminar(Paquete pac)
        {

            ServiceReference1.WebService1SoapClient cliente = new ServiceReference1.WebService1SoapClient();
            var paquetes = cliente.EliminarPaqueteAsync(pac.id);
            return View();


        }

        [HttpGet]
        public async Task<ActionResult> Consultar()
        {
            ViewBag.Message = "Your products page.";
            Paquete product = new Paquete();
            string urlAction = String.Format("WebService1.asmx/ConsultarPaquete");
            var client = new HttpClient();            
            client.BaseAddress = new Uri(@"http://localhost/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(urlAction);
            response.EnsureSuccessStatusCode();
            string lista= response.Content.ReadAsStringAsync().Result;
            List<Paquete> temp = JsonConvert.DeserializeObject<List<Paquete>>(lista);
            return View(temp);
        }

        [HttpGet]
        public async Task<ActionResult> ConsultarPorRemitente(string remitente)
        {
            remitente = "udla";
            ViewBag.Message = "Your products page.";
            Paquete product = new Paquete();
            string urlAction = String.Format("WebService1.asmx/ConsultarPaquete");
            var client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = await client.GetAsync(string.Format("WebService1.asmx/ConsultarPaquetePorRemitente?remitente={0}", remitente));
          
            response.EnsureSuccessStatusCode();
            string lista = response.Content.ReadAsStringAsync().Result;
            List<Paquete> temp = JsonConvert.DeserializeObject<List<Paquete>>(lista);
            return View(temp);
        }

        [HttpGet]
        public async Task<ActionResult> ConsultarPorDestintario(string destintario)
        {
            destintario = "marco";
            ViewBag.Message = "Your products page.";
            Paquete product = new Paquete();
            string urlAction = String.Format("WebService1.asmx/ConsultarPaquete");
            var client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(string.Format("WebService1.asmx/ConsultarPaquetePorDestinatario?destinatario={0}", destintario));

            response.EnsureSuccessStatusCode();
            string lista = response.Content.ReadAsStringAsync().Result;
            List<Paquete> temp = JsonConvert.DeserializeObject<List<Paquete>>(lista);
            return View(temp);
        }

        [HttpGet]
        public async Task<ActionResult> ConsultarPorFecha(string fecha)
        {
            fecha = "24/10/2016";
            DateTime fecha2 = Convert.ToDateTime(fecha);
            ViewBag.Message = "Your products page.";
            Paquete product = new Paquete();
            string urlAction = String.Format("WebService1.asmx/ConsultarPaquete");
            var client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(string.Format("WebService1.asmx/ConsultarPaquetePorFecha?fecha={0}", fecha));

            response.EnsureSuccessStatusCode();
            string lista = response.Content.ReadAsStringAsync().Result;
            List<Paquete> temp = JsonConvert.DeserializeObject<List<Paquete>>(lista);
            return View(temp);
        }

    }
}