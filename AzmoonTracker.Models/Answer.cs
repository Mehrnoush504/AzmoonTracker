using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AzmoonTracker.Models
{
    public class Answer
    {
        //fk to user participate in exam
        [ForeignKey("ExamParticipantId")]
        public virtual UserParticipateInExam ExamParticipant {get; set;}
        public int ExamParticipantId { get; set; }

        //fk to question
        [ForeignKey("QuestionId, ExamId")]
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(30)]
        public string ExamId { get; set; }

        //the answer itself
        public string AnswerText { get; set; }
    }
}
