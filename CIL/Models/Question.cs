﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CIL.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public DailyTest DailyTest { get; set; }
        public string Description { get; set; }
        public string DifficultyLevel { get; set; }
        public string CorrectAnswer { get; set; }

        [IgnoreDataMember]
        public ICollection<Answer> Answers { get; set; }
    }
}
