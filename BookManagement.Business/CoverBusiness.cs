
using BookManagement.Model.Interfaces;

namespace BookManagement.Business
{
    public class CoverBusiness : ICoverBusiness
    {
        public readonly ICoverRepository _coverRepository;

        public CoverBusiness(ICoverRepository coverRepository)
        {
            _coverRepository = coverRepository;
        }

        public void UploadFile(MemoryStream file, Guid id)
        {
            _coverRepository.UploadImage(file, id);
        }

        public async Task<MemoryStream> GetImage(Guid id)
        {
            return await _coverRepository.GetImage(id);
        }


    }
}
