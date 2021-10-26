using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.DTOs
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public Guid PassedUserId { get; set; }
        public Guid DailyTest { get; set; }
        public Guid Question { get; set; }
        public string QuestionAnswer { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public double? Score { get; set; }
    }
}
