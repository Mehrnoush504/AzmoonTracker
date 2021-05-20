using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzmoonTracker.Models
{
    public class UserParticipateInExam
    {
        [Key]
        public virtual AppUser Participant { get; set; }

        [Key]
        public virtual Exam Exam { get; set; }
    }
}
