using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.DTOs
{
    public class DailyTestResultDto
    {
        public Guid Id { get; set; }
        public Guid DailyTest { get; set; }
        public Guid PassedUserId { get; set; }
        public double Score { get; set; }
        public string Description { get; set; }
    }
}
