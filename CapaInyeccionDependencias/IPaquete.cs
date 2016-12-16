using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaInyeccionDependencias
{
    interface IPaquete
    {
        void Insertar(string destinatario, string remitente, string tipo, int cantidad, string estado);

        void Eliminar(int id);


         void Modificar(int id, string destinatario, string remitente, string tipo, int cantidad, string estado);



         object Consultar();


         object ConsultarPorFecha(DateTime fecha);



         object ConsultarPorRemitente(string remitente);

        object ConsultarPorDestinatario(string destinatario);
        
    }
}
