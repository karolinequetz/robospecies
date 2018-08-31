using System;
using HtmlAgilityPack;

namespace NovoExercicioSerie2
{
    public class Info
    {
        public string Tipo { get; set; }
        public string Dificuldade { get; set; }
        public string TempoPreparo { get; set; }
        public string TempoCozedura { get; set; }

        public void CapturaTipo(HtmlNode r)
        {
            var node = r.SelectSingleNode("./div/div[@class='prop']/span[1]");
            var texto = node.InnerText;
            this.Tipo = texto;
        }

        public void CapturaDificuldade(HtmlNode r)
        {
            var node = r.SelectSingleNode("./div/div[@class='prop']/span[2]");
            var texto = node.InnerText;
            this.Dificuldade = texto;
        }

        public void CapturaTempoPreparo(HtmlNode r)
        {
            var node = r.SelectSingleNode("./div/div[@class='prop']/span[3]");
            var texto = node.InnerText;
            this.TempoPreparo = texto;
        }
        public void CapturaCozedura(HtmlNode r)
        {
            var node = r.SelectSingleNode("./div/div[@class='prop']/span[4]");
            var texto = node.InnerText;
            this.TempoCozedura = texto;
        }

    }

}

