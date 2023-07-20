using BookManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Repository.Context
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { } 

        public DbSet<Book> Books { get; set; }
    }
}
