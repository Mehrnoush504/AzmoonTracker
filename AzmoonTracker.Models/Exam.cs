using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AzmoonTracker.Models
{
    public class Exam
    {
        [ForeignKey("CreatorId")]
        public virtual AppUser Creator { get; set; }
        public string CreatorId { get; set; }

        [Required]
        [MaxLength(30)]
        public String ExamId { get; set; }

        [Required]
        [MaxLength(70)]
        public string ExamName { get; set; }

        [Required]
        [MaxLength(80)]
        public string ClassName { get; set; }

        [Required]
        public Boolean IsPublic { get; set; }

        public int QuestionNum { get; set; }

        [Required]
        public DateTime StartTime { get; set; } = DateTime.Now;

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public Boolean IsFinished { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        //public virtual ICollection<UserParticipateInExam> ExamParticipants { get; set; }
    }
}
