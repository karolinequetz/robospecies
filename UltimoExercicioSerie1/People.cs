﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace UltimoExercicioSerie1
{
    class People
    {
        private HtmlNode item;

     
        public string Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Modified { get; set; }
        public bool vip { get; set; }

    }
}
