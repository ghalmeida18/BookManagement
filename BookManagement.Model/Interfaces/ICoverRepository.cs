namespace BookManagement.Model.Interfaces
{
    public interface ICoverRepository
    {
        public void UploadImage(MemoryStream file, Guid id);
        public Task<MemoryStream> GetImage(Guid id);
    }
}
