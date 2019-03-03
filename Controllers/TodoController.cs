using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)

        {
            _context = context;
            _context.Database.EnsureCreated();


            if (_context.TodoItem.Count() == 0)

            { 
                _context = context;
                _context.Database.EnsureCreated();

            }

        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.User.ToList();
        }

        [HttpGet("GetById")]
        public IActionResult GetUsersById(int id)
        {
            User users = _context.User.FirstOrDefault(x => x.Id == id);
            if (users == null)
            {
                return NotFound("Trazerni korisnik ne postohji");
            }

            return Ok(users);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
