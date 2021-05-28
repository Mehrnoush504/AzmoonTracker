using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzmoonTracker.ViewModels
{
    public class ChoiceViewModel
    {
        [Required]
        public int ChoiceNum { get; set; }

        [Required]
        public string ChoiceDescription { get; set; }

        [Required]
        public Boolean IsCorrect { get; set; }
    }
}
