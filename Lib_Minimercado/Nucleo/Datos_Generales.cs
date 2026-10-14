using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Minimercado.Nucleo
{
    public class Datos_Generales
    {
        public static string ObtenerStringConexion()
        {
            return "server=localhost;database=db_minimercado;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}
