using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTemplate.Models
{
    public class Game
    {
        public string Developer { get; set; }
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string GameImage { get; set; }
    }
}