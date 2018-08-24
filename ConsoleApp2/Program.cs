using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {

        static string url = "https://useast.ensembl.org/info/about/species.html";
       
        static void Main(string[] args)
        {
            //1 - Acesse o site "https://useast.ensembl.org/info/about/species.html" e inspecione a lista de espécies para identificar a estrutura da tabela
            //2 - Na Solution, crie uma classe Especie onde cada Coluna do site seja uma variável
            //3 - Atribua o link à variável URL do seu Robô
            //4 - Uma vez que você obtiver o html da página na variável "doc", aplique Xpath com as funções "SelectSingleNode" e "SelectNodes"
            //5 - Para cada linha capturada, crie uma objeto Especie e adicione a uma lista do tipo Especie

            var doc = getHtml(url);

            var lista = doc.DocumentNode.SelectNodes("//tbody/tr");

            var listaespecies = new List<species>();

            foreach (var l in lista)
            {
                var novaespecie = new species();

                var node = l.SelectSingleNode("./td[1]");
                novaespecie.commonName = node.InnerText;         

                node = l.SelectSingleNode("./td[2]");
                novaespecie.scientifName = node.InnerText;

                node = l.SelectSingleNode("./td[3]");
                novaespecie.taxonId = node.InnerText;

                node = l.SelectSingleNode("./td[4]");
                novaespecie.ensemblAssembly = node.InnerText;

                node = l.SelectSingleNode("./td[5]");
                novaespecie.accession = node.InnerText;

                node = l.SelectSingleNode("./td[6]");
                novaespecie.genebuildMethod = node.InnerText;

                node = l.SelectSingleNode("./td[7]");
                novaespecie.variationDatabase = node.InnerText;

                node = l.SelectSingleNode("./td[8]");
                novaespecie.regulationDatabase = node.InnerText;

                node = l.SelectSingleNode("./td[9]");
                novaespecie.preAssembly = node.InnerText;


                listaespecies.Add(novaespecie);
            }
        }

        public static HtmlDocument getHtml(string url)
        {
            var web = new HtmlWeb();

            HtmlDocument doc = web.Load(url);

            return doc;
        }
    }
}
