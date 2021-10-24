using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.DTOs
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public Guid DailyTest { get; set; }
        public string Description { get; set; }
        public string DifficultyLevel { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
