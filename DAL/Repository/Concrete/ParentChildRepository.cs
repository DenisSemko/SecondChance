using System;
using System.Collections.Generic;
using System.Text;
using CIL.Models;
using DAL.Repository.Abstract;

namespace DAL.Repository.Concrete
{
    public class ParentChildRepository : BaseRepository<ParentChild>, IParentChildRepository
    {
        public ParentChildRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
