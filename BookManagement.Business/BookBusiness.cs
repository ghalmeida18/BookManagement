using BookManagement.Model;
using BookManagement.Model.Exceptions;
using BookManagement.Model.Interfaces;
using BookManagement.Model.Validators;
using FluentValidation;

namespace BookManagement.Business
{
    public class BookBusiness : IBookBusiness
    {
        public readonly IBookRepository _bookRepository;

        public BookBusiness(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book Insert(Book book)
        {
            var result = new BookValidator().Validate(book);

            if (!result.IsValid)
                throw new InvalidBookException($"Can't create new register: {string.Join("," , result.Errors)}");

            _bookRepository.Insert(book);

            return book;
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book Get(Guid id)
        {
            Book? book = _bookRepository.Get(id);

            if (book is null)
                throw new InvalidBookException($"There is not a book with the id: {id}. Try again.");

            else return book;
            
        }

        public bool Delete(Guid id)
        {
            if (id.Equals(Guid.Empty))
                throw new InvalidBookException("Please, inform a valid Id.");

            if(!_bookRepository.CheckIfInserted(id))
                throw new InvalidBookException($"The book with id {id} was not found. Please, try again.");

            _bookRepository.Delete(id);

            return true;
        }

        public bool Update(Book book)
        {
            if(book.Id.Equals(Guid.Empty) 
                || ! _bookRepository.CheckIfInserted(book.Id)
                || ! new BookValidator().Validate(book).IsValid)
                throw new InvalidBookException("Please, inform a valid book.");

            _bookRepository.Update(book);

            return true;
        }
    }
}
