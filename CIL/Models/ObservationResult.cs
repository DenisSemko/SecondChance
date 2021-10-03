using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class ObservationResult
    {
        public Guid Id { get; set; }
        public User PassedUserId { get; set; }
        public string Type { get; set; }
        public double Measure { get; set; }
        public DateTime Date { get; set; }
        public double ResultAverage { get; set; }
        public string Description { get; set; }
    }
}
