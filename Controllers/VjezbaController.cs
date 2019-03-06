using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.EntityFrameworkCore.Query.Internal;


namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class VjezbaController : Controller
    {
        private static TodoContext _context;

        public VjezbaController(TodoContext context)
        {

            _context = context;

            context.Database.EnsureCreated();

        }



        //Declar class fields
        public int Number1 = 12;
        public int Number2 = 6;
        public string Name1 = "Mitar";
        public string Name2 = "Filip";
        public bool Status = false;
        public static List<int> Values;

        public enum Day
        {
            Mon,
            Tue,
            Wed,
            Thu,
            Fri,
            Sat,
            Sun
        }


        //Get: api/<controller>
        [HttpGet("GetInt1")]
        //Return int
        public int GetInt1()
        {
            if (Number1 + Number2 > 15)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        //Get: api/<controller>
        [HttpGet("GetInt2")]
        //Return int
        public int GetInt2()
        {
            if (Number2 + 5 >= Number1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        //Get: api/<controller>
        [HttpGet("GetString")]
        //Return string
        public string GetString()
        {
            return Name2;
        }

        //Get: api/<controller>
        [HttpGet("GetArr")]

        public int GetArr()
        {
            int[] Values;

            Values = new int[2];
            Values[0] = Number1;
            Values[1] = Number2;

            return Values[1];
        }


        //Add int elements to the Values list
        private void SetList(int num1, int num2)
        {

        }


        //Get: api/<controller>
        [HttpGet("GetEnum")]
        //Return enum value
        public string GetEnum()
        {
            string day = Day.Sat.ToString();
            return day;
        }


        //Get: api/<controller>
        [HttpGet("GetBool")]
        public bool GetBool()
        {
            string name = GetString();
            switch (name)
            {
                case "Mitar":
                    return true;
                    break;
                case "Filip":
                    return false;
                    break;

                default:
                    return false;

            }
        }


        //Get: api/<controller>
        [HttpGet("GetFor")]
        //Return number int from for loop
        public int GetFor()
        {

            int number = 1;

            for (int i = 1; i <= Number1; i++)
            {
                if (Number1 % i == 1)
                {
                    number = i;
                }
            }

            return number;
        }


        //Get: api/<controller>
        [HttpGet("GetArrList")]
        //Return count if elements in Array List
        public int GetArrList()
        {
            ArrayList List = new ArrayList();
            List.Add(Name1);
            List.Add(Status);

            return List.Count;
        }


        //Get: api/<controller>
        [HttpGet("GetStack/{name}")]
        //Return true if name is in the stack
        public bool GetStack(string name)
        {
            Stack Names = new Stack();
            Names.Push(Name1);
            Names.Push(Name2);

            if (Names.Contains(name))
            {
                Status = true;
            }

            return Status;

        }
    }

}






    







        


    


