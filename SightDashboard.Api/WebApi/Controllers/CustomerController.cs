using System;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Entities.Entity;
using Services.Exceptions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(_customerService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_customerService.GetById(c => c.Id == id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerEntity customer)
        {
            try
            {
                _customerService.Save(customer);
                return Ok();
            }   
            catch (CustomExceptions ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
        }
    }
}