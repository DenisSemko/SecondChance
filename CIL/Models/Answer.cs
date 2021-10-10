using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public User PassedUserId { get; set; }
        public DailyTest DailyTest { get; set; }
        public Question Question { get; set; }
        public string QuestionAnswer { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public double? Score { get; set; }
    }
}
