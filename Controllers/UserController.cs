using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TodoApi.Controllers
{
    [Route("api/User")]

    public class UserController : Controller

    {
        private readonly  TodoContext _context;

        public UserController(TodoContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            User user = _context.User.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {

                return NotFound("Nema trazenog korisnika");
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet("GetAll")]
        public async Task<List<User>> GetAll()
        {
            return await _context.User.ToListAsync();

        }


        [HttpDelete("DeleteById")]
        public IActionResult DeleteById(int id)
        {
            var user = _context.User.Find(id);

            if (user == null)
            {
                return NotFound("Ne postoji ovj korisnik");
            }
            return Ok(user);

        }

        [HttpPost("AddNewUser")]
        public IActionResult AddNewUser()
        {
            User user = new User();

            if(user != null)
            {
                _context.User.Add(user);
                _context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(int Id)
        {
            User user = new User();

            var searchUser = _context.User.Find(Id);

            if(searchUser != null)
            {
                searchUser.Name = user.Name;
                searchUser.BirthDate = user.BirthDate;
                searchUser.BirthPlace = user.BirthPlace;
                searchUser.Email = user.Email;

                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
            
        }



       
       




        









    }
}


       
      
       

       

       
      
    



