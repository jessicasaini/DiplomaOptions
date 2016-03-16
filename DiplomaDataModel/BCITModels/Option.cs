using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OptionsWebsite.Models.BCITModels
{
    public class Option
    {
        [Key]
        public int OptionId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 5)]
        public string Title { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

    }
}