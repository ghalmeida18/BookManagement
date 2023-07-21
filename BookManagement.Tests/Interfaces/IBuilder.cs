namespace BookManagement.Tests.Interfaces
{
    public interface IBuilder<T> where T : class
    {
        void WithId(Guid id);
        T Build();
    }
}
