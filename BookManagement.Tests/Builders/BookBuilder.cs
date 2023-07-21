using BookManagement.Model;
using BookManagement.Tests.Interfaces;

namespace BookManagement.Tests.Builders
{
    public class BookBuilder : IBuilder<Book>
    {
        private readonly Book _book = new();
        public Book Build()
        {
            return _book;
        }

        public void WithId(Guid id)
        {
            _book.Id = id;
        }

        public void WithTitle(string title)
        {
            _book.Title = title;
        }

        public void WithYear(int year)
        {
            _book.Year = year;
        }

        public void WithAuthor(string author)
        {
            _book.Author = author;
        }
    }
}
