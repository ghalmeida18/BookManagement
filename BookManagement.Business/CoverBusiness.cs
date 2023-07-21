
using BookManagement.Model.Exceptions;
using BookManagement.Model.Interfaces;

namespace BookManagement.Business
{
    public class CoverBusiness : ICoverBusiness
    {
        public readonly ICoverRepository _coverRepository;
        public readonly IBookRepository _bookRepository;

        public CoverBusiness(ICoverRepository coverRepository, IBookRepository bookRepository)
        {
            _coverRepository = coverRepository;
            _bookRepository = bookRepository;
        }

        public void UploadFile(MemoryStream file, Guid id)
        {
            _coverRepository.UploadImage(file, id);
        }

        public async Task<MemoryStream> GetImage(Guid id)
        {
            if(!_bookRepository.CheckIfInserted(id))
                throw new InvalidBookException($"The {id} book doens't exist in the database. Please, check the id.");

            return await _coverRepository.GetImage(id);
        }
    }
}
