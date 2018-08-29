using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoExercicioSerie1
{
    class Program
    { public static string url = "https://gist.githubusercontent.com/dalgard/3651234da390712c04f5/raw/fa56b499c10051af1cfdb9f71f8d9e5595cb3660/peopleMock.json";
        private static List<People> listaPessoas = new List<People>();
        static void Main(string[] args)
        {

            HtmlDocument doc = GetHtml(url);
            var lista = doc.DocumentNode.SelectNodes("//body/pre");

            foreach (var item in lista)
            {
                //People nova =(item);

              
            }
    }
        public static HtmlDocument GetHtml(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            return doc;
        }
    }
}
