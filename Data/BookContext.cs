using ApplicationForTest.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookStore.Data
{
    public class BookContext : DbContext, IBookContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                    new Book
                    {
                        Id = 1,
                        Author = "Автор 1",
                        Title = "Книга 1",
                        Year = 2020
                    },
                    new Book
                    {
                        Id = 2,
                        Author = "Автор 2",
                        Title = "Книга 2",
                        Year = 2018
                    },
                    new Book
                    {
                        Id = 3,
                        Author = "Автор 3",
                        Title = "Книга 3",
                        Year = 2019
                    },
                     new Book
                     {
                         Id = 4,
                         Author = "Автор 4",
                         Title = "Книга 4",
                         Year = 2022
                     }
                );
        }
    }


}
