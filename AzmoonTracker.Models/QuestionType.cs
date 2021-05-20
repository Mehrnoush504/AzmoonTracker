using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzmoonTracker.Models
{
    public class QuestionType
    {
        [Key]
        public int TypeId { get; set; }

        public string QuestionName { get; set; }
    }
}
