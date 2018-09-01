using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoExercicioSerie2
{
    class Program
    {
        public static string index = "https://pt.petitchef.com/lista-de-receitas";

        private static string url = "https://pt.petitchef.com/{0}";
        public static List<Receita> receitas = new List<Receita>();
        static void Main(string[] args)
        {
            var doc = GetHtml(index);

            var prox = doc.DocumentNode.SelectSingleNode("//div[@class='pages']/span/following-sibling::a");
            string novaUrl = string.Empty;

            int i = 1;
            while (TemAlgo(prox, out novaUrl))
            {
                var linhas = doc.DocumentNode.SelectNodes("//div[@class='item clearfix']");

                foreach (var linha in linhas)
                    ReceitasCheff(linha);

                doc = GetHtml(novaUrl);

                if(i == 11)
                {
                    Console.Write("lalalala");
                }
                i++;
                prox = doc.DocumentNode.SelectSingleNode("//div[@class='pages']/span/following-sibling::a");
            }

        }
        public static HtmlDocument GetHtml(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            return doc;
        }
        public static void ReceitasCheff(HtmlNode r)
        {
            var verifica = r.SelectSingleNode("./div/h2[@class='ir-title']/a");
            if (verifica != null)
            {
                var novaReceita = new Receita();

                novaReceita.CapturaAvaliacaoNota(r);
                novaReceita.CapturaVotos(r);
                novaReceita.CapturaNome(r);
                novaReceita.CapturaIngredientes(r);
                novaReceita.CapturaIngredientes(r);
                novaReceita.CapturaLinkImagem(r);
                novaReceita.CapturaInformacoes(r);

                receitas.Add(novaReceita);
            }
        }

        private static bool TemAlgo(HtmlNode node, out string texto)
        {
            texto = string.Empty;

            if (node == null)
                return false;

            texto = "https://pt.petitchef.com/" + node.Attributes["href"].Value;
            return true;
        }
    }
}
