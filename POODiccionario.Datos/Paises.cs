using POODiccionario.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POODiccionario.Entidades
{
    public class Paises
    {
        private Dictionary<string,Pais> paises { get; set; }
        private Dictionary<string,List<Pais>> paisesPorRegion { get; set; }

        public Paises()
        {
            paises = new Dictionary<string,Pais>(); 
            paises=CsvReader.GetAllCountries();
        }

        public int GetCountPaises()
        {
            return paises.Count();
        }

        public bool EliminarPaisPorCodigo(string CodigoParaBorrar)
        {
            if(paises.ContainsKey(CodigoParaBorrar)) 
            { 
                paises.Remove(CodigoParaBorrar);
                Console.WriteLine("Pais eliminado");
                return true;
            }
            Console.WriteLine("Codigo de país mal ingresado");
            return false;
        }

        public Dictionary<string, Pais> GetPaises()
        {
            return paises;
        }

        public Dictionary<string, List<Pais>> GetPaisesPorRegion()
        {
            return paisesPorRegion;
        }

        public KeyValuePair<string, Pais> GetCountryAt(int indice)
        {
            if (indice >= 0 || indice < paises.Count())
            {
               return this.paises.ElementAt(indice);
            }
            throw new Exception("El Pais esta fuera del rango");

        }

        //public Dictionary<string, List<Pais>> GetRegiones()
        //{
        //    var Diccionario= new Dictionary<string, List<Pais>>();
        //    foreach (var item in paises.Values)
        //    {
        //        if (Diccionario.ContainsKey(item.Continente))
        //        {
        //           var ListaPais= Diccionario[item.Continente];
        //           ListaPais.Add(item);
        //        }
        //        else
        //        {
        //            var PaisLista= new List<Pais>();
        //            PaisLista.Add(item);
        //            Diccionario.Add(item.Continente, PaisLista);
        //        }
        //    }
        //    return Diccionario;
        //}
        public List<string> GetRegiones()
        {
            var Diccionario = new Dictionary<string, List<Pais>>();
            foreach (var item in paises.Values)
            {
                if (Diccionario.ContainsKey(item.Continente))
                {
                    var ListaPais = Diccionario[item.Continente];
                    ListaPais.Add(item);
                }
                else
                {
                    var PaisLista = new List<Pais>();
                    PaisLista.Add(item);
                    Diccionario.Add(item.Continente, PaisLista);
                }
            }
            return Diccionario.Keys.ToList();
        }

        public List<Pais> GetPaisesPorRegiones(string continente)
        {
            var ListaContinentePais = new List<Pais>();
            foreach (var item in paises.Values)
            {
                if (item.Continente.ToUpperInvariant() == continente)
                {
                    ListaContinentePais.Add(item);
                }
            }
            return ListaContinentePais;
        }

        public static bool operator +(Paises p, Pais b)
        {
            if (p!=b)
            {
                p.paises.Add(b.Codigo, b);
                return true;
            }
            return false;
        }

        public static bool operator -(Paises a, Pais b)
        {
            if(a==b) {
                a.paises.Remove(b.Codigo);
                return true;
            }
            return false;
        }

        public static bool operator ==(Paises a, Pais b)
        {
            foreach (Pais item in a.GetPaises().Values)
            {
                if (item==b)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Paises a, Pais b)
        {
            return !(a == b);
        }

   
    }
}
