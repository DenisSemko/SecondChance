using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class DailyTestResult
    {
        public Guid Id { get; set; }
        public DailyTest DailyTest { get; set; }
        public User PassedUserId { get; set; }
        public int CorrectAnswers { get; set; }
        public double Score { get; set; }
        public string Description { get; set; }

    }
}
