using BookManagement.Model.Interfaces;
using Xunit;
using Moq;
using BookManagement.Business;
using BookManagement.Model;

namespace BookManagement.Tests
{
    public class BookBusinessTest
    {
        private readonly Mock<IBookRepository> _bookRepository = new();

        [Fact]
        public void BookBusiness_Insert_OK()
        {
            Book book = GenerateDefaultBook();

            _bookRepository.Setup(s => s.Insert(It.IsAny<Book>()));

            BookBusiness business = new(_bookRepository.Object);

            var insertedBook = business.Insert(book);

            Assert.NotNull(insertedBook);
            Assert.Equal(book.Id, insertedBook.Id);
        }

        [Fact]
        public void BookBusiness_GetAll_OK()
        {
            Book book = GenerateDefaultBook();

            _bookRepository.Setup(s => s.GetAll()).Returns(new List<Book>() { book });

            BookBusiness business = new(_bookRepository.Object);

            var books = business.GetAll();

            Assert.NotNull(books);
            Assert.True(books.Any());
        }

        [Fact]
        public void BookBusiness_Delete_OK()
        {
            _bookRepository.Setup(s => s.Delete(It.IsAny<Guid>()));
            _bookRepository.Setup(s => s.CheckIfInserted(It.IsAny<Guid>())).Returns(true);

            BookBusiness business = new(_bookRepository.Object);

            var isDeleted = business.Delete(Guid.NewGuid());

            Assert.True(isDeleted);
        }

        [Fact]
        public void BookBusiness_Update_OK()
        {
            Book book = GenerateDefaultBook();

            _bookRepository.Setup(s => s.Delete(It.IsAny<Guid>()));
            _bookRepository.Setup(s => s.CheckIfInserted(It.IsAny<Guid>())).Returns(true);

            BookBusiness business = new(_bookRepository.Object);

            var isUpdated = business.Update(book);

            Assert.True(isUpdated);
        }

        [Fact]
        public void BookBusiness_Get_OK()
        {
            Book book = GenerateDefaultBook();

            _bookRepository.Setup(s => s.Get(It.IsAny<Guid>())).Returns(book);

            BookBusiness business = new(_bookRepository.Object);

            var bookObtained = business.Get(Guid.NewGuid());

            Assert.NotNull(bookObtained);
            Assert.NotEqual(Guid.Empty, bookObtained.Id);
        }

        #region Default Values
        private static Book GenerateDefaultBook()
        {
            return new Book()
            {
                Author = "Author",
                Id = Guid.NewGuid(),
                Title = "Title",
                Year = DateTime.Now.Year
            };
        }
        #endregion


    }
}