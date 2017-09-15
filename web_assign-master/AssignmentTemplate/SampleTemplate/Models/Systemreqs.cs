using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.ComponentModel.DataAnnotations;

namespace SampleTemplate.Models
{
    public class Systemreqs
    {
        public string Title { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Storage { get; set; }
        public string Video { get; set; }

    }
}