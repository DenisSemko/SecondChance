using CIL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Abstract
{
    public interface IParentChildRepository : IRepository<ParentChild>
    {
        public Task<IEnumerable<ParentChild>> GetByParentId(Guid id);
    }
}
