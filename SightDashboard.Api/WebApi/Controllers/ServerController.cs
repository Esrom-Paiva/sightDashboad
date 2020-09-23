using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private IServerService _serverService;
        public ServerController(IServerService serverService)
        {
            _serverService = serverService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_serverService.GetAll());
        }

        [HttpGet("{id}",Name ="GetServer")]
        public IActionResult GetById(int id)
        {
            return Ok(_serverService.GetById(s => s.Id == id));
        }

        [HttpPut("{id}", Name = "GetServer")]
        public IActionResult Message(int id, [FromBody] ServerMessage message)
        {
            var serverUpdated = _serverService.Put(id, message);
            if (serverUpdated is null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }
    }
}