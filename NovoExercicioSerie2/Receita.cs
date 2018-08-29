﻿using HtmlAgilityPack;

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
                //novaReceita.Avaliacao = text;         
            }


        }
        public void CapturaVotos(HtmlNode r)
        {

            var node = r.SelectSingleNode("./div/div[contains(@class, 'ir-vote')]/i[contains(@class, 'note-fa')]");
            if (node != null)
            {
                var text = node.Attributes["title"].Value;

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
       
    }
}