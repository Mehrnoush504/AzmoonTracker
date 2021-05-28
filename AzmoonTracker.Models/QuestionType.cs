using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzmoonTracker.Models
{
    public class QuestionType
    {
        public int TypeId { get; set; }

        [Required]
        [MaxLength(20)]
        public string TypeName { get; set; }
    }
}
