using POODiccionario.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POODiccionario.Datos
{
    public static class CsvReader
    {
        private static string _cvsFilePath = @"C:\Users\uri8m\Downloads\Pop by Largest Final.csv";
        public static Dictionary<string, Pais> GetAllCountries()
        {
            var diccionario= new Dictionary<string, Pais>();
            using (var reader = new StreamReader(_cvsFilePath))
            {
                while(!reader.EndOfStream)
                {
                    string csvLine=reader.ReadLine();
                    Pais pais = ConstruirPais(csvLine);
                    diccionario.Add(pais.Codigo, pais);
                }
            }
            return diccionario;
        }

        private static Pais ConstruirPais(string csvLine)
        {
            string[] archivos = csvLine.Split(',');
            string code= string.Empty;
            string name= string.Empty;
            string region= string.Empty;
            string poptext=string.Empty;

            switch (archivos.Length) 
            {
                case 4:
                    name = archivos[0];
                    code = archivos[1];
                    region = archivos[2];
                    poptext= archivos[3];
                    break;
                case 5:
                    name = archivos[0];
                    code = $"{archivos[1]} {archivos[2]}";
                    region = archivos[3];
                    poptext= archivos[4];
                    break;
            }

           
            return new Pais(code, name, region, poptext);
        }

        public static Dictionary<string, Pais> Guardar(Pais pais, string codigo)
        {
            var Diccionario= new Dictionary<string, Pais>();
            var paises = new Paises();
            if (paises.EliminarPaisPorCodigo(pais.Codigo))
            {
                Diccionario.Remove(pais.Codigo);
            }
            //if(Diccionario.Add(pais.Codigo, pais))
            //{

            //}
            return Diccionario;
        }
    }
}
