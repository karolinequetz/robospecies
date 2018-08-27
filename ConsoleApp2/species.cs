//-----------------------------------------------------------------------
// <copyright file="species.cs" company="Sprocket Enterprises">
//     Copyright (c) Sprocket Enterprises. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ConsoleApp2
{
    /// <summary>
    /// Class Species
    /// </summary>
    public class Species
    {
        /// <summary>
        /// Gets or sets species name
        /// </summary>
        public string CommonName { get; set; }

        /// <summary>
        /// Gets or sets scientific name
        /// </summary>
        public string ScientifName { get; set; }

        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public string TaxonId { get; set; }

        /// <summary>
        /// Gets or sets Assembly
        /// </summary>
        public string EnsemblAssembly { get; set; }

        /// <summary>
        /// Gets or sets Accession
        /// </summary>
        public string Accession { get; set; }

        /// <summary>
        /// Gets or sets Gene Method
        /// </summary>
        public string GenebuildMethod { get; set; }

        /// <summary>
        /// Gets or sets Variation database
        /// </summary>
        public string VariationDatabase { get; set; }

        /// <summary>
        /// Gets or sets Regulation database
        /// </summary>
        public string RegulationDatabase { get; set; }

        /// <summary>
        /// Gets or sets Pre assembly
        /// </summary>
        public string PreAssembly { get; set; }
    }
}
