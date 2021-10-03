using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CIL.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int DifficultyLevel { get; set; }

        [IgnoreDataMember]
        public ICollection<DailyTest> DailyTests { get; set; }

        [IgnoreDataMember]
        public ICollection<Answer> Answers { get; set; }
    }
}
