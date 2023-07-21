
namespace BookManagement.Model.Interfaces
{
    public interface ICoverBusiness
    {
        public void UploadFile(MemoryStream file, Guid id);
        public Task<MemoryStream> GetImage(Guid id);
    }
}
