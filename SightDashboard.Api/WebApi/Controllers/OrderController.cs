using Common;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public IActionResult Get(int pageIndex, int pageSize)
        {

            var data = _orderService.GetAll(o => o.Customer);

            return Ok(new ResultApi()
            {
                Data = new PaginatedResponse<OrderEntity>(data, pageIndex, pageSize),
                Total = Math.Ceiling((double)data.Count() / pageSize)
            });
        }

        [HttpGet("byState")]
        public IActionResult getByState()
        {
            var data = _orderService.GetAll(o => o.Customer).GroupBy(o => o.Customer.State).ToList();

            var groupedResult = data
                    .Select(grp => new ResultApi()
                    {
                        Data = grp.Key,
                        Total = Convert.ToDouble(grp.Sum(x => x.Total))
                    })
                    .OrderByDescending(res => res.Total);
            return Ok(groupedResult);
        }
    }
}
