using BookManagement.Model.Interfaces;
using Xunit;
using Moq;
using BookManagement.Business;
using BookManagement.Model.Exceptions;

namespace BookManagement.Tests
{
    public class CoverBusinessTest
    {
        private readonly Mock<IBookRepository> _bookRepository = new();
        private readonly Mock<ICoverRepository> _coverRepository = new();

        [Fact]
        public void CoverBusiness_Upload_OK()
        {
            using MemoryStream memoryStream = new();
            _coverRepository.Setup(s => s.UploadImage(It.IsAny<MemoryStream>(), It.IsAny<Guid>())).Verifiable();

            CoverBusiness business = new(_coverRepository.Object, _bookRepository.Object);

            business.UploadFile(memoryStream, Guid.NewGuid());
        }

        [Fact]
        public void CoverBusiness_GetImage_OK()
        {
            using MemoryStream memoryStream = new();

            _bookRepository.Setup(s => s.CheckIfInserted(It.IsAny<Guid>())).Returns(true);
            _coverRepository.Setup(s => s.GetImage(It.IsAny<Guid>())).ReturnsAsync(memoryStream);

            CoverBusiness business = new(_coverRepository.Object, _bookRepository.Object);

            var response = Task.Run(() => business.GetImage(Guid.NewGuid()));

            Assert.NotNull(response);
        }

        [Fact]
        public void CoverBusiness_GetImage_NotYetInsertedBook_NOK()
        {
            using MemoryStream memoryStream = new();

            _bookRepository.Setup(s => s.CheckIfInserted(It.IsAny<Guid>())).Returns(false);

            CoverBusiness business = new(_coverRepository.Object, _bookRepository.Object);

            Assert.ThrowsAsync<InvalidBookException>(() => business.GetImage(Guid.NewGuid()));
        }
    }
}