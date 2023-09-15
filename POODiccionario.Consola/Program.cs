using POODiccionario.Datos;
using POODiccionario.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POODiccionario.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Creando un diccionario");

            //Pais Argentina = new Pais("ARG", "Argentina", "America", "45.580.642");
            //Pais Chile = new Pais("CHI", "Chile", "America", "45.603.424");
            //Pais Peru = new Pais("PER", "Peru", "America", "34.543.233");
            //var paises = new Dictionary<string, Pais>()
            //{
            //    {Argentina.Codigo,Argentina}
            //};
            //paises.Add(Chile.Codigo, Chile);

            //Console.WriteLine("Ingrese el código del País deseado ");
            //var codigo=Console.ReadLine();
            ////Generar Validador
            //if (!paises.ContainsKey(Peru.Codigo))
            //{
            //    paises.Add(Peru.Codigo, Peru);
            //    Console.WriteLine($"{Peru.MostrarInformacion()} AGREGADO!!!");
            //}
            //else
            //{
            //    Console.WriteLine($"{Peru.Codigo} dicho código ya existe");
            //}

            //Console.WriteLine("Ingrese un código de País");
            //string codigoIngresado=Console.ReadLine();
            //if( paises.TryGetValue(codigoIngresado.ToUpper(), out Pais paisEnDiccionario))
            //{
            //    Console.WriteLine(paisEnDiccionario.MostrarInformacion());
            //}
            //else
            //{
            //    Console.WriteLine($"El código ingresado [{codigoIngresado}] no es valido  ");
            //}

            //Console.WriteLine("Ingrese número del indice ");
            //int indice=int.Parse(Console.ReadLine());

            //if (indice >= 0 && indice < paises.Count())
            //{
            //    var elementoEnDiccionario= paises.ElementAt(indice);
            //    Console.WriteLine($"{elementoEnDiccionario.Key}");
            //    Console.WriteLine($"{elementoEnDiccionario.Value.Nombre}");
            //}
            //else
            //{
            //    Console.WriteLine("Indice fuera de rango");
            //}

            //foreach (var item in paises)
            //{
            //    Console.WriteLine($"{item.Key} - {item.Value.Nombre}");
            //}

            //foreach (var item in paises.Values)
            //{
            //    Console.WriteLine($"{item.Nombre}");
            //}

            //foreach (var item in paises.Keys)
            //{
            //    Console.WriteLine($"{item}");
            //}
            var paises = new Paises();
            //Console.WriteLine("Ingrese el continente deseado ");
            //string Continente=Console.ReadLine();
            //var regiones= paises.GetPaisesPorRegiones(Continente.ToUpperInvariant());

            //foreach (var p in regiones)
            //{
            //    Console.WriteLine(p.MostrarInformacion());
            //}

            //Console.WriteLine(paises.GetCountPaises());
            //foreach (var item in paises.GetPaises())
            //{
            //    Console.WriteLine(item.Value.MostrarInformacion());
            //}
            //Console.WriteLine($"{paises.GetCountPaises()}");
            //Console.WriteLine();
            
            Console.WriteLine("Ingrese el código para eliminar pais");
            string codigo = Console.ReadLine();
            paises.EliminarPaisPorCodigo(codigo.ToUpper());
            foreach (var item in paises.GetPaises())
            {
                Console.WriteLine(item.Value.MostrarInformacion());
            }
            Console.ReadLine();
        }
    }
}
