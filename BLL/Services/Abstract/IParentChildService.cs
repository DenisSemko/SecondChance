using CIL.DTOs;
using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IParentChildService
    {
        public Task<IEnumerable<ParentChild>> Get();
        public Task<ParentChild> GetById(Guid id);
        public Task<ParentChild> Add(ParentChild parentChildUser);
        public Task<ParentChild> Add(ParentChildDto parentChildUser);
    }
}
