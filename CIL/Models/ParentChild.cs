using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.Models
{
    public class ParentChild
    {
        public Guid Id { get; set; }
        public User ParentId { get; set; }
        public User ChildId { get; set; }
    }
}
