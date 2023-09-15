using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POODiccionario.Entidades
{
    public class Pais
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Continente { get; set; }
        public string Poblacion { get; set; }
        public Pais()
        {
            
        }
        public Pais(string codigo, string nombre, string continente, string poblacion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Continente = continente;
            Poblacion = poblacion;
        }
        public string MostrarInformacion()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"Código: {Codigo.ToUpper()}");
            sb.AppendLine($"Nombre: {Nombre}");
            sb.AppendLine($"Continente: {Continente}");
            sb.AppendLine($"Población: {Poblacion}");
            return sb.ToString();
        }

        public static bool operator ==( Pais a, Pais b )
        {
            if (a.Codigo == b.Codigo)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=( Pais a, Pais b )
        {
            return !(a == b);
        }
    }
}
