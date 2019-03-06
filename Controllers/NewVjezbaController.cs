using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TodoApi.Models;


namespace TodoApi.Controllers
{
    [Route("api/[controller]")]

    public class NewVjezbaController : ControllerBase
    {
        public readonly TodoContext _context;

        public NewVjezbaController(TodoContext context)
        {
            context.Database.EnsureCreated();

            _context = context;
        }


        private string name;
        private string surname;
        private int age;

        



        public NewVjezbaController(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        [HttpGet("GetPerson/Sttring")]
        public string getName()
        {
            return name;
        }

        [HttpGet("GetPersonName")]
        public void setName(string name)
        {
            this.name = name;
        }

        [HttpGet("GetPersonString")]
        public string toString()
        {
            return "Person:" + surname + "," + name + ".Age:" + age;
        }

        [HttpGet("GetPersonN")]
        public void Person(string result)
        {
            result = "Student";

        }



    }
}
