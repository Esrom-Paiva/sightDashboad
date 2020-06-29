using Repositories.Context;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseContext _context;
        public UnitOfWork(BaseContext baseContext)
        {
            _context = baseContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }


        public void RollBack()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
