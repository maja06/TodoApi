using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{

    [Route("api/LINQ")]
    public class LINQController : ControllerBase 
    {
        public readonly  TodoContext _context;

        public LINQController(TodoContext context)
        {
            context.Database.EnsureCreated();

            _context = context;
        }

        public int[] Numbers = new int[6] { 6, 7, 18, 27, 29, 100 };
        public int[] EvenNumbers = new int[10] { 6, 12, 36, 72, 144, 200, 300, 420, 600, 800 }; 


      

        [HttpGet("GetLowNumber")]
        public IActionResult GetLowNumber()
        {
            

            var LowNumberQuery =
            from n in Numbers
            where n > 10
            select n;

            if(LowNumberQuery.Any())
            {
                return Ok(LowNumberQuery.ToList());
            }
            return NotFound();
        }


  
        [HttpGet("GetNumber")]
        public IActionResult GetNumber()
        {


            var NUmberQuery =
                from num in Numbers
                where num > 6 && num < 50
                select num;

            if(NUmberQuery.Any())
            {
                return Ok(NUmberQuery.ToList());
            }
            return BadRequest();
            
           
        }

       

        [HttpGet("EvenNum")]
        public IActionResult EvenNum()
        {
            var EvenQuery =
                from num in EvenNumbers
                where num > 50 && num < 600
                select num;

            if (EvenQuery.Any())
            {
                return Ok(EvenQuery.ToList());
            }
            return BadRequest();
        }



        [HttpGet("EvenN/Id")]
        public IActionResult GetEvenN(int id)
        {
            var allUsers = _context.User;

            var Query5 =
                from user in allUsers
                from X in EvenNumbers
                where id == user.Id && id < X
                select new { user, X };

            if (Query5.Any())
            {
                return Ok(Query5.ToList());
            }
            return NotFound();
        }
        



        [HttpGet("UserId")]
        public IActionResult GetUserId()
        {
            var allusers = _context.User;


            var Query1 =
                from user in allusers
                where user.Id > 100 && user.Id < 150
                select user;


            if (Query1.Any())
            {
                return Ok(Query1.ToList());
            }

            return NotFound();
        }




        [HttpGet("GetEmail")]
        public IActionResult GetEmail(string email)
        {
            var allusers = _context.User;

            var Query2 =
                from user in allusers
                where email == user.Email
                select user;

            if (Query2.Any())
            {
                return Ok(Query2.ToList());
            }
            return NoContent();
        }




        [HttpGet("GetName/BirthPlace")]
        public IActionResult GetName(string name, string birthPlace)
        {

            var allUsers = _context.User;

            var Query3 =
                from user in allUsers
                where name == user.Name && birthPlace == ""
                select user;

            if (Query3.Any())
            {
                return Ok(Query3.ToList());
            }
            return NotFound("Nema trazenog korisnika");

        }



        [HttpGet("Id/Name")]
        public IActionResult GetIdName(int id, string name)
        {
            var allUsers = _context.User;

            var Query4 =
                from user in allUsers
                where id == user.Id && name == "Anna"
                select user;

            if (Query4.Any())
            {
                return Ok(Query4.ToList());
            }
            return NotFound();
        }



        [HttpGet("GetDate")]
        public IActionResult GetDate()
        {
            var allUsers = _context.User;

            var Query6 =
                from user in allUsers
                where user.BirthDate >= new DateTime(5 / 18 / 1997)
                select user;

            if (Query6.Any())
            {
                return Ok(Query6.ToList());
            }
            return NotFound();
        }



        [HttpGet("Num/EvenNum")]
        public IActionResult NumEvenNum() 
        {
            var Query7 =
                from x in Numbers
                from y in EvenNumbers
                where x < y
                select new { x, y };

            if(Query7.Any())
            {
                return Ok(Query7.ToList());
            }
            return NotFound();


        }







    }
}
