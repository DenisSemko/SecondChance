using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CIL.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int Level { get; set; }

        [IgnoreDataMember]
        public ICollection<GameResult> GameResults { get; set; }
    }
}
