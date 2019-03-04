using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        private readonly IHostingEnvironment environment;

        public TodoContext(DbContextOptions<TodoContext> options, IHostingEnvironment environment)
            : base(options)
        {
            this.environment = environment;
        }


        public DbSet<TodoItem> TodoItem { get; set; }
        public DbSet<User> User { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var path = Path.Combine(environment.ContentRootPath, "users.json");
            var jsonString = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<User>>(jsonString);
            modelBuilder.Entity<User>().HasData(list);
        }

      
    }
}