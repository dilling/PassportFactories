using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using PassportCodeChallenge.Data;
using PassportCodeChallenge.Models;

namespace PassportCodeChallenge.Controllers
{
    [Route("api/[controller]")]
    public class FactoryController : Controller
    {
        private readonly DataContext _context;
        private readonly IHubContext<FactoryNotificationHub, IFactoryHubClient> _hubContext;

        public FactoryController(DataContext context, IHubContext<FactoryNotificationHub, IFactoryHubClient> hubContext) {
            _context = context;
            _hubContext = hubContext;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Factories.ToList());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Factory factory = _context.Factories.FirstOrDefault(e => e.FactoryId == id);
            if (factory == null)
            {
                return NotFound("Factory not found");
            }
 
            return Ok(factory);
        }

        [HttpPost]
        public IActionResult Post() {
            var factory = new Factory();
            _context.Add(factory);
            _context.SaveChanges();

            _hubContext.Clients.All.BroadcastMessage("Create", factory);

            return CreatedAtRoute(
                "get",
                new { Id = factory.FactoryId },
                factory
            );
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Factory factory)
        {
            if (factory == null)
            {
                return BadRequest("Factory is null");
            }

            Factory factoryToUpdate = _context.Factories.FirstOrDefault(f => f.FactoryId == id);
            if (factoryToUpdate == null)
            {
                return NotFound("Factory not found");
            }
            
            factoryToUpdate.Name = factory.Name;
            factoryToUpdate.Children = factory.Children;
            _context.SaveChanges();

            _hubContext.Clients.All.BroadcastMessage("Update", factoryToUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Factory factory = _context.Factories.FirstOrDefault(f => f.FactoryId == id);
            if (factory == null)
            {
                return NotFound("Factory not found");
            }
 
            _context.Remove(factory);
            _context.SaveChanges();

            _hubContext.Clients.All.BroadcastMessage("Delete", factory);

            return NoContent();
        }

    }
}