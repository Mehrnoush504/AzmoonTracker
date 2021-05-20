using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzmoonTracker.Models
{
    public class Choice
    {
        [Key]
        public virtual Question Question { get; set; }

        [Key]
        public virtual Exam Exam { get; set; }

        [Key]
        public int ChoiceNum { get; set; }

        public String ChoiceDescription { get; set; }
        public Boolean IsCorrect { get; set; }

    }
}
