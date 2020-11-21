using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyOwnProject.Models
{
   public class Frequency
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Frequency Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Frequency Count")]
        public int FrequencyCount { get; set; }

    }
}
