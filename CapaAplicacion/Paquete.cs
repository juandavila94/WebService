using System;
using CapaDatos;
     
namespace CapaAplicacion
{
    public class Paquete
    {
        private int id { get; set; }
        private string destinatario { get; set; }
        private string remitente { get; set; }
        private DateTime fecha { get; set; }
        private string tipo { get; set; }
        private int cantidad { get; set; }
        DatosPaquete bd = new DatosPaquete();

        public void Insertar(string destinatario, string remitente, string tipo, int cantidad, string estado)
        {
            bd.Insertar(destinatario, remitente, tipo, cantidad, estado);
        }

        public void Eliminar(int id)
        {
            bd.Eliminar(id);
        }

        public void Modificar(int id, string destinatario, string remitente, string tipo, int cantidad, string estado)
        {
            bd.Modificar(id, destinatario, remitente, tipo, cantidad, estado);
        }

        public object Consultar()
        {
            return bd.Consultar(); 
        }

        public object ConsultarPorFecha(DateTime fecha)
        {
            var lista = bd.ConsultarPorFecha(fecha);
            return lista;
        }

        public object ConsultarPorRemitente(string remitente)
        {
            var lista = bd.ConsultarPorRemitente(remitente);
            return lista;
        }
        public object ConsultarPorDestinatario(string destinatario)
        {
            var lista = bd.ConsultarPorDestinatario(destinatario);
            return lista;
        }

    }
}
