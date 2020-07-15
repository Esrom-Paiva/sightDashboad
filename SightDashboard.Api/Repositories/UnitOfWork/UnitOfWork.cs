using Repositories.Context;
using Repositories.Interface;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly BaseContext _context;

        private IOrderRepository _orderRepository;
        private IServerRepository _serverRepository;
        private ICustomerRepository _customerRepository;

        public IOrderRepository OrderRepository
        {
            get
            {
                _orderRepository ??= new OrderRepository(_context);
                return _orderRepository;
            }
        }

        public IServerRepository ServerRepository
        {
            get
            {
                _serverRepository ??= new ServerRepository(_context);
                return _serverRepository;
            }   
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                _customerRepository ??= new CustomerRepository(_context);
                return _customerRepository;
            }
        }
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