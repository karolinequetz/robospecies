//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Sprocket Enterprises">
//     Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using HtmlAgilityPack;

    /// <summary>
    /// Program class
    /// </summary>
    public partial class Program
    {
        /// <summary>
        /// Url de consult
        /// </summary>
        private static string url = "https://useast.ensembl.org/info/about/species.html";

        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args">Main args</param>
        public static void Main(string[] args)
        {
            Regex eR = new Regex("formosa$", RegexOptions.None);

            var doc = GetHtml(url);
            var lista = doc.DocumentNode.SelectNodes("//tbody/tr");
            var listaespecies = new List<Species>();

            foreach (var l in lista)
            {
                Species novaespecie = CriaSpecie(l);

                listaespecies.Add(novaespecie);
            }

            foreach (var li in lista)
            {
                if (eR.IsMatch(li.InnerText))
                {
                    Console.WriteLine(string.Format("{0}", li.InnerText));
                }
            }
        }

        private static Species CriaSpecie(HtmlNode l)
        {
            var novaespecie = new Species();

            var node = l.SelectSingleNode("./td[1]");
            novaespecie.CommonName = node.InnerText;

            node = l.SelectSingleNode("./td[2]");
            novaespecie.ScientifName = node.InnerText;

            node = l.SelectSingleNode("./td[3]");
            novaespecie.TaxonId = node.InnerText;

            node = l.SelectSingleNode("./td[4]");
            novaespecie.EnsemblAssembly = node.InnerText;

            node = l.SelectSingleNode("./td[5]");
            novaespecie.Accession = node.InnerText;

            node = l.SelectSingleNode("./td[6]");
            novaespecie.GenebuildMethod = node.InnerText;

            node = l.SelectSingleNode("./td[7]");
            novaespecie.VariationDatabase = node.InnerText;

            node = l.SelectSingleNode("./td[8]");
            novaespecie.RegulationDatabase = node.InnerText;

            node = l.SelectSingleNode("./td[9]");
            novaespecie.PreAssembly = node.InnerText;
            return novaespecie;
        }

        /// <summary>
        /// Get Html
        /// </summary>
        /// <param name="url">url html</param>
        /// <returns>html url</returns>
        public static HtmlDocument GetHtml(string url)
        {
            var web = new HtmlWeb();

            HtmlDocument doc = web.Load(url);

            return doc;
        }
       
    }
}
