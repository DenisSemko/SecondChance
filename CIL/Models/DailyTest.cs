using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CIL.Models
{
    public class DailyTest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string KidsAge { get; set; }

        [IgnoreDataMember]
        public ICollection<Question> Questions { get; set; }

        [IgnoreDataMember]
        public ICollection<DailyTestResult> DailyTestResults { get; set; }

        [IgnoreDataMember]
        public ICollection<Answer> Answers { get; set; }
    }
}
