using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzmoonTracker.Models
{
    public class Exam
    {
        public virtual AppUser Creator { get; set; }

        [Key]
        public String ExamId { get; set; }

        public string ExamName { get; set; }
        public string ClassName { get; set; }
        public Boolean IsPublic { get; set; }
        public int QuestionNum { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Boolean IsFinished { get; set; }
    }
}
