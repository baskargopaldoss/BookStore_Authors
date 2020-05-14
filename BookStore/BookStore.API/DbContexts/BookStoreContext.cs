using BookStore.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.API.DbContexts
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
           : base(options)
        {
        }

        public BookStoreContext() { }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    FirstName = "Berry",
                    LastName = "Griffin Beak Eldritch",
                    DateOfBirth = new DateTime(1650, 7, 23),
                    MainCategory = "Ships"
                },
                new Author()
                {
                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    FirstName = "Nancy",
                    LastName = "Swashbuckler Rye",
                    DateOfBirth = new DateTime(1668, 5, 21),
                    MainCategory = "Rum"
                },
                new Author()
                {
                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    FirstName = "Eli",
                    LastName = "Ivory Bones Sweet",
                    DateOfBirth = new DateTime(1701, 12, 16),
                    MainCategory = "Singing"
                },
                new Author()
                {
                    Id = Guid.Parse("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                    FirstName = "Arnold",
                    LastName = "The Unseen Stafford",
                    DateOfBirth = new DateTime(1702, 3, 6),
                    MainCategory = "Singing"
                },
                new Author()
                {
                    Id = Guid.Parse("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                    FirstName = "Seabury",
                    LastName = "Toxic Reyson",
                    DateOfBirth = new DateTime(1690, 11, 23),
                    MainCategory = "Maps"
                },
                new Author()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                    FirstName = "Rutherford",
                    LastName = "Fearless Cloven",
                    DateOfBirth = new DateTime(1723, 4, 5),
                    MainCategory = "General debauchery"
                },
                new Author()
                {
                    Id = Guid.Parse("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                    FirstName = "Atherton",
                    LastName = "Crow Ridley",
                    DateOfBirth = new DateTime(1721, 10, 11),
                    MainCategory = "Rum"
                }
                );
           

            base.OnModelCreating(modelBuilder);
        }
    }
}
