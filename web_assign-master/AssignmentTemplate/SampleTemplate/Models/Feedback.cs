using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SampleTemplate.Models
{
    public class Feedback
    {
        [Display(Name = "Time Submitted")]
        [Required]
        [RegularExpression("[A-Za-z]+")]
        public DateTime TimeSubmitted { get; set; }

        [Display(Name = "Content")]
        [Required]
        [RegularExpression("[A-Za-z]+")]
        public string Content { get; set; }

        [Display(Name = "Read")]
        [Required]
        [RegularExpression("[A-Za-z]+")]
        public bool Read { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
