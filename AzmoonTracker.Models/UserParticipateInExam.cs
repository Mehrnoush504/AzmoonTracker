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
        public string ExamFK { get; set; }

        //student grade
        public int Grade { get; set; }

        //primary key id
        [Required]
        public int ExamParticipantId { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
