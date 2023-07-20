
namespace BookManagement.Model.Interfaces
{
    public interface IBookBusiness
    {
        public void Insert(Book book);
        public List<Book> GetAll();
        public Book Get(Guid id);
        public void Delete(Guid id);
        public void Update(Book book);
    }
}
