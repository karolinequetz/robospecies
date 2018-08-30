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

        public void CapturaTipo(HtmlNode li)
        {
         
            var node = li.SelectSingleNode("//div[@class='prop']/span[1]");
           var texto = node.InnerText;
        }

        public  void CapturaDificuldade(HtmlNode r)
        {
            var node = r.SelectSingleNode("//div[@class='prop']/span[2]");
           var text = node.InnerText;
        }
        public  void CapturaTempoPreparo(HtmlNode r)
        {
            var node = r.SelectSingleNode("//div[@class='prop']/span[3]");
            var text = node.InnerText;
        }
        public  void CapturaCozedura(HtmlNode r)
       {
            var node = r.SelectSingleNode("//div[@class='prop']/span[4]");
            var text = node.InnerText;

        }
      //  public static void CapturaTipo(HtmlNode r)
        //{
        //    var node = r.SelectSingleNode("//div[@class='prop']/span[@class ='pi']");
        //    var text = node.InnerText;


        //public static Info CapturarInformacoes(HtmlNode li)
        //{

        //    var informa = new Info();


        //    var node = li.SelectSingleNode("//div[@class='prop']/span[1]");
        //    informa.Tipo = node.InnerText;

        //    node = li.SelectSingleNode("//div[@class='prop']/span[2]");
        //    informa.Dificuldade = node.InnerText;

        //    node = li.SelectSingleNode("//div[@class='prop']/span[3]");
        //    informa.TempoPreparo = node.InnerText;

        //    node = li.SelectSingleNode("//div[@class='prop']/span[4]");
        //    informa.TempoCozedura = node.InnerText;





        //    return informa;

    }



}
    //public static void CapturaDificuldade(HtmlNode r)
    //{
    //    var node = r.SelectSingleNode("//div[@class='prop']/span[1]");
    //    var text = node.InnerText;
    //}
    //public static void CapturaTempoPreparo(HtmlNode r)
    //{
    //    var node = r.SelectSingleNode("//div[@class='prop']/span[3]");
    //    var text = node.InnerText;
    //}
    //public static void CapturaCozedura(HtmlNode r)
    //{
    //    var node = r.SelectSingleNode("//div[@class='prop']/span[4]");
    //    var text = node.InnerText;

    //}
