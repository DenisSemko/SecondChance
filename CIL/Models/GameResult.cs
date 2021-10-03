using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class GameResult
    {
        public Guid Id { get; set; }
        public User PassedUserId { get; set; }
        public Game Game { get; set; }
        public double Points { get; set; }
        public string Description { get; set; }
    }
}
