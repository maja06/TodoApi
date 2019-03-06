using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    //Ovo je samo vjezba koda 

    public class Primjer
    {
        public string Name { get; set; }
        public int ID { get; set; }

    }

    public class Nova : Primjer
    {
        public string Surname { get; set; }

    }

    public class Sledeca
    {


        public int id { get; set; }

    }



    public class Provjera
    {


        public static void Model()
        {
            List<Primjer> lista = new List<Primjer>();

            lista.Add(new Nova
            {
                ID = 6,
                Name = "Maja",
                Surname = "Radojicic"
            });

            foreach (var glavna in lista)
            {
                var nova = glavna as Nova;

                if (nova == null)
                {

                }

            }

            List<Sledeca> lista1 = new List<Sledeca>();
            lista1.Add(new Sledeca { id = 12 });

            List<Sledeca> lista2 = new List<Sledeca>()
            {
                new Sledeca(){ id = 15},
                new Sledeca(){ id = 20}
            };




        }

















    }
}
