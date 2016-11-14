using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosPaquete
    {
        IS2Entities bd = new IS2Entities();
        public void Insertar(string destinatario, string remitente, string tipo, int cantidad,string estado) {
            using (var bd = new IS2Entities())
            {
                var courseList = bd.insertar( destinatario,  remitente,  tipo, cantidad,estado);
                bd.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var bd = new IS2Entities())
            {
                var courseList = bd.eliminar(id);
                bd.SaveChanges();
            }
        }

        public void Modificar(int id,string destinatario, string remitente, string tipo, int cantidad, string estado)
        {
            using (var bd = new IS2Entities())
            {
                var courseList = bd.modificar(id,destinatario, remitente, tipo, cantidad, estado);
                bd.SaveChanges();
            }
        }

        public object Consultar()
        {
                return bd.consultar().ToList();
        }

        public object ConsultarPorFecha(DateTime fecha)
        {
            using (var bd = new IS2Entities())
            {
                var courseList = bd.consultarPorFecha(fecha.Date).ToList();
                bd.SaveChanges();
                return courseList;
            }
        }

        public object ConsultarPorRemitente(string remitente)
        {
            using (var bd = new IS2Entities())
            {
                var courseList = bd.consultarPorRemitente(remitente).ToList();
                bd.SaveChanges();
                return courseList;
            }
        }
        public object ConsultarPorDestinatario(string destinatario)
        {
            using (var bd = new IS2Entities())
            {
                var courseList = bd.consultarPorDestinatario(destinatario).ToList();
                bd.SaveChanges();
                return courseList;
            }
        }
    }
}
