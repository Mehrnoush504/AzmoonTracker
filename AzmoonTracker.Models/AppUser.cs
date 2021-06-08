using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzmoonTracker.Models
{
    public class AppUser : IdentityUser
    {
        public int ExamsCreatedNum { get; set; }
        public int ExamsLeftNum { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }

        public virtual ICollection<UserParticipateInExam> ExamsParticipated { get; set; }
    }
}
