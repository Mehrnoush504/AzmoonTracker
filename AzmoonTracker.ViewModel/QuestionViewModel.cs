using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzmoonTracker.ViewModels
{
    public class QuestionViewModel
    {
        [Required]
        public int QuestionTypeId { get; set; }

        [Required]
        public int QuestionNum { get; set; }

        [Required]
        public string QuestionDescription { get; set; }

        [Required]
        public ICollection<ChoiceViewModel> Choices { get; set; }
    }
}
