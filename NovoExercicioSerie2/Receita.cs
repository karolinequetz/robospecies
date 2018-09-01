using HtmlAgilityPack;
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

                string votos = split[1];
                votos = Regex.Match(votos, @"\d+").Value;
                this.Votos = votos.Length;
            }
        }

        public void CapturaNome(HtmlNode r)
        {

            var node = r.SelectSingleNode("./div/h2[@class='ir-title']/a");
            var text = node.Attributes["title"];
            this.Nome = text.Value;
        }
        public void CapturaIngredientes(HtmlNode r)
        {
            var node = r.SelectSingleNode("./div/div[@class = 'ingredients']");
            var texto = node.InnerText;
            this.Ingredientes = texto;

        }
        public void CapturaLinkReceita(HtmlNode r)
        {
            var node = r.SelectSingleNode("./div/h2/a");
            var texto = node.InnerText;
            this.LinkReceita = texto;

        }
        public void CapturaLinkImagem(HtmlNode r)
        {
            var node = r.SelectSingleNode("./div[@class='i-left']/img");
            string link = "https://pt.petitchef.com/";
            this.LinkImagem = link + node.Attributes["src"].Value;
        }
        public void CapturaInformacoes(HtmlNode r)
        {
            var info = new Info();

            info.CapturaTipo(r);
            info.CapturaDificuldade(r);
            info.CapturaTempoPreparo(r);
            info.CapturaCozedura(r);

            this.Informacoes = info;
        }
    }
}
