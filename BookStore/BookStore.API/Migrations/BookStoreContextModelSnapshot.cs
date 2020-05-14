﻿// <auto-generated />
using System;
using BookStore.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.API.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    partial class BookStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStore.API.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MainCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)),
                            FirstName = "Berry",
                            LastName = "Griffin Beak Eldritch",
                            MainCategory = "Ships"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1668, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)),
                            FirstName = "Nancy",
                            LastName = "Swashbuckler Rye",
                            MainCategory = "Rum"
                        },
                        new
                        {
                            Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1701, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)),
                            FirstName = "Eli",
                            LastName = "Ivory Bones Sweet",
                            MainCategory = "Singing"
                        },
                        new
                        {
                            Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1702, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)),
                            FirstName = "Arnold",
                            LastName = "The Unseen Stafford",
                            MainCategory = "Singing"
                        },
                        new
                        {
                            Id = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1690, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)),
                            FirstName = "Seabury",
                            LastName = "Toxic Reyson",
                            MainCategory = "Maps"
                        },
                        new
                        {
                            Id = new Guid("2aadd2df-7caf-45ab-9355-7f6332985a87"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1723, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)),
                            FirstName = "Rutherford",
                            LastName = "Fearless Cloven",
                            MainCategory = "General debauchery"
                        },
                        new
                        {
                            Id = new Guid("2ee49fe3-edf2-4f91-8409-3eb25ce6ca51"),
                            DateOfBirth = new DateTimeOffset(new DateTime(1721, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)),
                            FirstName = "Atherton",
                            LastName = "Crow Ridley",
                            MainCategory = "Rum"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
