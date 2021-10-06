using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.Abstract
{
    public interface IUnitOfWork
    {

        void Complete();
        bool HasChanges();
    }
}
