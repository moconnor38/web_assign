using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SampleTemplate.Models
{
    public class UserModel
    {
        [Display (Name = "First Name")]
        [Required]
        [RegularExpression("[A-Za-z]+")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [RegularExpression("[A-Za-z]+")]
        public string LastName { get; set; }
        
        //add username UNIQUE

        [Required]
        [EmailAddress]
        public string Email { get; set; } //also unique

        [Required]
        [StringLength(15, ErrorMessage =
            "Password entered must be 6-15 characters long",
            MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [Required]
        [StringLength(15, ErrorMessage = "Password entered must be 6-15 characters long",
            MinimumLength =6)]
        public string ComparePassword { get; set; }
    }
}