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
        private ICustomerService _customerService;

        public OrderController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_orderService.GetById(o => o.Id == id, o => o.Customer));
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public IActionResult GetPaginated(int pageIndex, int pageSize)
        {

            var data = _orderService.GetAll(o => o.Customer);

            return Ok(new ResultApi()
            {
                Data = new PaginatedResponse<OrderEntity>(data, pageIndex, pageSize),
                Total = Math.Ceiling((double)data.Count() / pageSize)
            });
        }

        [HttpGet("ByState")]
        public IActionResult GetByState()
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

        [HttpGet("ByCustomer/{nCustomer}")]
        public IActionResult GetByCustomer(int nCustomer)
        {
            var data = _orderService.GetAll(o => o.Customer).GroupBy(o => o.Customer.Id).ToList();

            var groupedResult = data
                    .Select(grp => new ResultApi()
                    {
                        Data = _customerService.GetById(c => c.Id == grp.Key).Name,
                        Total = Convert.ToDouble(grp.Sum(x => x.Total))
                    })
                    .OrderByDescending(res => res.Total)
                    .Take(nCustomer);

            return Ok(groupedResult);
        }
    }
}
