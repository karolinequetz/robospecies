﻿using HtmlAgilityPack;
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
            int i;

            var doc = GetHtml(index);
            var lista = doc.DocumentNode.SelectNodes("//div[@id = 'recipe-list']/div"); 

            foreach (var node in lista)
            {
                if (HasNext(node, out i))
                {
                    doc = GetHtml(string.Format(url, node.Attributes["href"].Value));
                    var linhas = node.SelectNodes("//div[@class='item clearfix']");

                    receitas.AddRange(from linha in linhas select ReceitasCheff(linha));
                }
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
            novaReceita.capturaInformacao(r);


            return novaReceita;
        }
        private static bool HasNext(HtmlNode node, out int i)
        {
            var li = node.InnerText;
            return int.TryParse(li, out i);



        }
    }
}
