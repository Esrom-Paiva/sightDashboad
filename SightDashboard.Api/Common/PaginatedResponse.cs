using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class PaginatedResponse<T>
    {
            public int Total { get; set; }
            public IEnumerable<T> Data { get; set; }

        public PaginatedResponse(IEnumerable<T> data, int index, int len)
        {
            Data = data.Skip((index - 1) * len).Take(len).ToList();
            Total = data.Count();
        }
    }
}
