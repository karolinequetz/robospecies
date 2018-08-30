﻿using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace NovoExercicioSerie2
{
    class Receita
    {

        public double Avaliacao { get; set; }
        public int Votos { get; set; }
        public string Nome { get; set; }
        public string Ingredientes { get; set; }
        public string LinkReceita { get; set; }
        public string LinkImagem { get; set; }
        public Info Informacoes { get; set; }

        public void CapturaAvaliacaoNota(HtmlNode r)
        {
            var node = r.SelectSingleNode("./div/div[contains(@class, 'ir-vote')]/i[contains(@class, 'note-fa')]");

            if (node != null)
            {
                var text = node.Attributes["title"].Value;

                var split = text.Split('/');

                string avaliacao = split[0];

           
               // string votos = split[1];
                
               // votos = Regex.Match(votos, @"\d+").Value;

                    //.Replace(" votos", string.Empty);
                //novaReceita.Avaliacao = text;   
                
            }


        }
        public void CapturaVotos(HtmlNode r)
        {

            var node = r.SelectSingleNode("./div/div[contains(@class, 'ir-vote')]/i[contains(@class, 'note-fa')]");
            if (node != null)
            {
                var text = node.Attributes["title"].Value;
                var split = text.Split('/');

                string votos = split[2];
                votos = Regex.Match(votos, @"\d+").Value;
            }
        }
        public void CapturaNome(HtmlNode r)
        {

            var node = r.SelectSingleNode("//h2[@class='ir-title']/a");
            var text = node.Attributes["title"];
        }
        public void CapturaIngredientes(HtmlNode r)
        {
            var node = r.SelectSingleNode("//div[@class = 'ingredients']");
           

        }
        public void CapturaLinkReceita(HtmlNode r)
        {
            var node = r.SelectSingleNode("//h2/a");

        }
        public void CapturaLinkImagem (HtmlNode r)
        {
            var node = r.SelectSingleNode("//div[@class='i-left']/img");
        }
        public void capturaInformacao (HtmlNode r)
        {
            Informacoes.CapturaTipo(r);
            Informacoes.CapturaDificuldade(r);
            Informacoes.CapturaTempoPreparo(r);
            Informacoes.CapturaDificuldade(r);
        }
      
       
    }
}
