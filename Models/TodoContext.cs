using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            
        }


        public DbSet<TodoItem> TodoItem { get; set; }
        public DbSet<User> User { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var jsonString = File.ReadAllText("users.json");
            var list = JsonConvert.DeserializeObject<List<User>>(jsonString);
            modelBuilder.Entity<User>().HasData(list);
        }

      
    }
}