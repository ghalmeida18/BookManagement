using BookManagement.Model;
using BookManagement.Model.Interfaces;

namespace BookManagement.Business
{
    public class BookBusiness : IBookBusiness
    {
        public readonly IBookRepository _bookRepository;

        public BookBusiness(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Insert(Book book)
        {
            _bookRepository.Insert(book);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book Get(Guid id)
        {
            return _bookRepository.Get(id);
        }

        public void Delete(Guid id)
        {
            _bookRepository.Delete(id);
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
