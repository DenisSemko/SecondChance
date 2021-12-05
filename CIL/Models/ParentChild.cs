using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class ParentChild
    {
        public Guid Id { get; set; }
        public User Parent { get; set; }
        public User Child { get; set; }
    }
}
