using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.API.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
           : base(options)
        {
        }

        public UserContext() { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      // seed the database with dummy data
      modelBuilder.Entity<User>().HasData(
            new User()
            {
              UserId = "1",
              FirstName = "John",
              LastName = "Smith",
              Email = "John.Smith@gmail.com",
              Role = "Admin",
              Password = "admin"
            },
            new User()
            {
              UserId = "2",
              FirstName = "Jane",
              LastName = "Doe",
              Email = "Jane.Doe@gmail.com",
              Role = "Developer",
              Password = "dev"
            }
          ); 
           

            base.OnModelCreating(modelBuilder);
        }
    }
}
