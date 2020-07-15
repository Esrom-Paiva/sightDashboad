using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity;

namespace Repositories.Context
{
    public class BaseContext : DbContext
    {
        private readonly string _connection;
        public BaseContext(string connection)
        {
            _connection = connection;
        }
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { set; get; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Server> Servers { get; set; }
    }
}
