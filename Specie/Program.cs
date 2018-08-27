using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2;
using HtmlAgilityPack;


namespace Specie
{
    class Program
    {
        private static string url = "https://www.worldwildlife.org/species/directory?direction=desc&sort=extinction_status";
        private static string url2 = "https://www.worldwildlife.org/species/directory?direction=desc&page=2&sort=extinction_status";
        private static List<SpecieDirectory> listaSpecie = new List<SpecieDirectory>();
        static void Main(string[] args)
        {

            var doc = GetHtml(url);
            var lista = doc.DocumentNode.SelectNodes("//tbody/tr");


            foreach (var li in lista)
            {
                SpecieDirectory novaSpecie = Species(li);

                listaSpecie.Add(novaSpecie);
            }

        }
        private static SpecieDirectory Species(HtmlNode li)
        {
            var novaSpecie = new SpecieDirectory();
            var node = li.SelectSingleNode("./td[1]");
            novaSpecie.CommonName = node.InnerText;

            node = li.SelectSingleNode("./td[2]");
            novaSpecie.ScientificName = node.InnerText;

            node = li.SelectSingleNode("./td[3]");
            novaSpecie.ConservationStatus = node.InnerText;
            return novaSpecie;
        }
        public static HtmlDocument GetHtml(string url)
        {
            var web = new HtmlWeb();

            var doc = web.Load(url);
            return doc;
        }


    }
}
