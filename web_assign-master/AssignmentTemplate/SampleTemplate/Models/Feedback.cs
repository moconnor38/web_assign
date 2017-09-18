using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTemplate.Models
{
    public class Feedback
    {
        public DateTime TimeSubmitted { get; set; }
        public string Content { get; set; }
        public bool Read { get; set; }
    }
}
