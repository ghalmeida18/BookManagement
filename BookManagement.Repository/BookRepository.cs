
using BookManagement.Model;
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

        public void Insert(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book? Get(Guid id)
        {
            return _context.Books.FirstOrDefault(b => b.Id.Equals(id));
        }

        public void Delete(Guid id)
        {
            Book book = new() { Id = id };

            _context.Attach(book);
            _context.Remove(book);
           
            _context.SaveChanges();

        }

        public Book Update(Book book)
        {
            _context.Update(book);
            _context.SaveChanges();

            return book;
        }

        public bool CheckIfInserted(Guid id)
        {
            return _context.Books.Any(b => b.Id.Equals(id));
        }
    }
}
