namespace BookManagement.Model.Exceptions
{
    public class InvalidBookException : Exception
    {
        public InvalidBookException(string mensagem) : base(mensagem) { }
    }
}
