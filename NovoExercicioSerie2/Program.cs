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
            var lista = doc.DocumentNode.SelectNodes("//div[@class='pages']/a");

            foreach (var node in lista)
            {
                var linhas = node.SelectNodes("//div[@class='item clearfix']");

                foreach (var linha in linhas)
                    ReceitasCheff(linha);

                if (HasNext(node, out i))
                {
                    doc = GetHtml(string.Format(url, node.Attributes["href"].Value));
                }
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

        private static bool HasNext(HtmlNode node, out int i)
        {
            var li = node.InnerText;
            return int.TryParse(li, out i);



        }
    }
}
