
namespace BookManagement.Model.Interfaces
{
    public interface IBookBusiness
    {
        public Book Insert(Book book);
        public List<Book> GetAll();
        public Book Get(Guid id);
        public bool Delete(Guid id);
        public bool Update(Book book);
    }
}
