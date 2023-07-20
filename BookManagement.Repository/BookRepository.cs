
using BookManagement.Model.Interfaces;
using BookManagement.Repository.Context;

namespace BookManagement.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }
    }
}
