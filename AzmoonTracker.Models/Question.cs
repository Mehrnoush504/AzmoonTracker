using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzmoonTracker.Models
{
    public class Question
    {
        public virtual QuestionType QuestionType { get; set; }
        [Key]
        public virtual Exam Exam { get; set; }
        [Key]
        public int QuestionNum { get; set; }
        public string QuestionDescription { get; set; }

    }
}
