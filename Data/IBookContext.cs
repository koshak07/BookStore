using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForTest.Data
{
    public interface IBookContext
    {
        public DbSet<Book> Books { get; set; }

    }
}