using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AzmoonTracker.Models
{
    public class UserParticipateInExam
    {
        
        [ForeignKey("ParticipantFK")]
        public virtual AppUser Participant { get; set; }
        [Required]
        public string ParticipantFK { get; set; }

        [ForeignKey("ExamFK")]
        public virtual Exam Exam { get; set; }
        [Required]
        public int ExamFK { get; set; }
    }
}
