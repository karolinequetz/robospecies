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
        public static string url = "https://pt.petitchef.com/lista-de-receitas";
        public static List<Receita> receitas = new List<Receita>();
        static void Main(string[] args)
        {
            var doc = GetHtml(url);
            var lista = doc.DocumentNode.SelectNodes("//div[@id = 'recipe-list']/div");

            foreach (var item in lista)
            {
                ReceitasCheff(item);
            }
        }
        public static HtmlDocument GetHtml(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            return doc;
        }
        public static Receita ReceitasCheff(HtmlNode r)
        {
            var novaReceita = new Receita();

            novaReceita.CapturaAvaliacaoNota(r);
            novaReceita.CapturaVotos(r);
            novaReceita.CapturaNome(r);
            novaReceita.CapturaIngredientes(r);
            novaReceita.CapturaIngredientes(r);
            novaReceita.CapturaLinkImagem(r);




            return novaReceita;
        }
    }
}
