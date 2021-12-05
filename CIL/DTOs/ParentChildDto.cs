using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.DTOs
{
    public class ParentChildDto
    {
        public Guid Id { get; set; }
        public Guid Parent { get; set; }
        public Guid Child { get; set; }
    }
}
