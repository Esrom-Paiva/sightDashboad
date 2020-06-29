using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interface
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    }
}
