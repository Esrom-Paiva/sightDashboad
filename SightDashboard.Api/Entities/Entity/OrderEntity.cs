﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public CustomerEntity Customer { get; set; }
        public decimal Total { get; set; }
        public DateTime Placed { get; set; }
        public DateTime? Completed { get; set; }
    }
}
