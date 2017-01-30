using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC
{
    interface InyectorDependencias
    {
        ActionResult Insertar(Paquete pac);
        ActionResult Eliminar(Paquete pac);
        ActionResult Modificar(Paquete pac);
        Task<ActionResult> Consultar();
        Task<ActionResult> ConsultarPorFecha(string fecha);
        Task<ActionResult> ConsultarPorRemitente(string remitente);
        Task<ActionResult> ConsultarPorDestintario(string destintario);
    }
}
