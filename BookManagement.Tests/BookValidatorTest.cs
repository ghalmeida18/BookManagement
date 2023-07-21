using BookManagement.Model;
using BookManagement.Model.Validators;
using BookManagement.Tests.Builders;
using Xunit;
using Xunit.Sdk;

namespace BookManagement.Tests
{
    public class BookValidatorTest
    {
        [Fact]
        public void BookValidator_OK()
        {
            BookBuilder bookBuilder = new();

            bookBuilder.WithId(Guid.NewGuid());
            bookBuilder.WithTitle("Title");
            bookBuilder.WithYear(DateTime.Now.Year);
            bookBuilder.WithAuthor("Author");

            var result = new BookValidator().Validate(bookBuilder.Build());

            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void BookValidator_InvalidId_NOK()
        {
            BookBuilder bookBuilder = new();

            bookBuilder.WithId(Guid.Empty);
            bookBuilder.WithTitle("Title");
            bookBuilder.WithYear(DateTime.Now.Year);
            bookBuilder.WithAuthor("Author");

            var result = new BookValidator().Validate(bookBuilder.Build());

            Assert.False(result.IsValid);
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void BookValidator_InvalidTitle_NOK()
        {
            BookBuilder bookBuilder = new();

            bookBuilder.WithId(Guid.NewGuid());
            bookBuilder.WithTitle("");
            bookBuilder.WithYear(DateTime.Now.Year);
            bookBuilder.WithAuthor("Author");

            var result = new BookValidator().Validate(bookBuilder.Build());

            Assert.False(result.IsValid);
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void BookValidator_InvalidAuthor_NOK()
        {
            BookBuilder bookBuilder = new();

            bookBuilder.WithId(Guid.NewGuid());
            bookBuilder.WithTitle("Title");
            bookBuilder.WithYear(DateTime.Now.Year);
            bookBuilder.WithAuthor("");

            var result = new BookValidator().Validate(bookBuilder.Build());

            Assert.False(result.IsValid);
            Assert.True(result.Errors.Any());
        }

        [Fact]
        public void BookValidator_InvalidYar_NOK()
        {
            BookBuilder bookBuilder = new();

            bookBuilder.WithId(Guid.NewGuid());
            bookBuilder.WithTitle("Title");
            bookBuilder.WithYear(0);
            bookBuilder.WithAuthor("Author");

            var result = new BookValidator().Validate(bookBuilder.Build());

            Assert.False(result.IsValid);
            Assert.True(result.Errors.Any());
        }
    }
}