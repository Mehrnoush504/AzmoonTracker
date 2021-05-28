using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzmoonTracker.ViewModels
{
    public class ExamViewModel
    {
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

        [Required]
        public Boolean IsFinished { get; set; }

        [Required]
        public int QuestionNum { get; set; }

        [Required]
        public DateTime StartTime { get; set; } = DateTime.Now;

        [Required]
        public DateTime EndTime { get; set; }

        //[Required]
        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}
