using CapaAplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;



namespace WS
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ConsultarPaquete()
        {
            Paquete paquete = new Paquete();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            string json = "";
            var lista = paquete.Consultar();
            json = jss.Serialize(lista);
            json = Regex.Replace(json, @"\""\\/Date\((-?\d+)\)\\/\""", "$1");
            json.Replace(@"\", string.Empty);
            Context.Response.Write(json);
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void InsertarPaquete(string destinatario, string remitente, string tipo, int cantidad, string estado)
        {
            Paquete pac = new Paquete();
            pac.Insertar(destinatario, remitente, tipo, cantidad, estado);

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ModificarPaquete(int id, string destinatario, string remitente, string tipo, int cantidad, string estado)
        {
            Paquete pac = new Paquete();
            pac.Modificar(id, destinatario, remitente, tipo, cantidad, estado);

        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void EliminarPaquete(int id)
        {
            Paquete pac = new Paquete();
            pac.Eliminar(id);
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ConsultarPaquetePorDestinatario(string destinatario)
        {
            Paquete paquete = new Paquete();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";  
            Context.Response.Write(jss.Serialize(paquete.ConsultarPorDestinatario(destinatario) ));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ConsultarPaquetePorRemitente(string remitente)
        {
            Paquete paquete = new Paquete();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            string json = "";
            var lista = paquete.ConsultarPorRemitente(remitente);
            Context.Response.Write(jss.Serialize(lista));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ConsultarPaquetePorFecha(DateTime fecha)
        {
            Paquete paquete = new Paquete();           
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            string json = "";
            var lista = paquete.ConsultarPorFecha(fecha.Date);
            Context.Response.Write(jss.Serialize(lista));
        }

    }
}
