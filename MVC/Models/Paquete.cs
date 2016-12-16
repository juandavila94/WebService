using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Paquete
    {

        public int id { get; set; }
   
        public string destinatario { get; set; }
    
        public string remitente { get; set; }
    
        public DateTime fecha { get; set; }

        public string tipo { get; set; }
        
        public int cantidad { get; set; }
        
        public string estado { get; set; }
    }
}