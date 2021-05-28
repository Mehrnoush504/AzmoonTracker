using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AzmoonTracker.Models
{
    public class Choice
    {
        [ForeignKey("QuestionId, ExamId")]
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(30)]
        public string ExamId { get; set; }

        public int ChoiceNum { get; set; }

        [Required]
        public string ChoiceDescription { get; set; }

        [Required]
        public Boolean IsCorrect { get; set; }
    }
}
