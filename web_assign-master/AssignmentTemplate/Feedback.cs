using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTemplate.Models
{
    public class Feedback
    {
        private DateTime TimeSubmitted { get; set; }
        private string Content { get; set; }
        private bool Read { get; set; }
    }
}
