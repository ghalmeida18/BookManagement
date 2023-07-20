namespace BookManagement.Model.Interfaces
{
    public interface IBookRepository
    {
        public void Insert(Book book);
        public List<Book> GetAll();
        public Book? Get(Guid id);
        public void Delete(Guid id);
        public Book Update(Book book);
        public bool CheckIfInserted(Guid id);
    }
}
