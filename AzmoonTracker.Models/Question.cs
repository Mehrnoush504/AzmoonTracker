using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AzmoonTracker.Models
{
    public class Question
    {
        [ForeignKey("TypeId")]
        public virtual QuestionType QuestionType { get; set; }
        [Required]
        public int TypeId { get; set; }

        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }
        [Required]
        [MaxLength(30)]
        public string ExamId { get; set; }

        public int QuestionNum { get; set; }

        [Required]
        public string QuestionDescription { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }
    }
}
