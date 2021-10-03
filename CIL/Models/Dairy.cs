using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class Dairy
    {
        public Guid Id { get; set; }
        public User PassedUserId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
    }
}
