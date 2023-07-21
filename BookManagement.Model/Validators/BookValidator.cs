using FluentValidation;

namespace BookManagement.Model.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Year).NotNull().GreaterThan(0);
            RuleFor(b => b.Author).NotNull().NotEmpty();
            RuleFor(b => b.Title).NotNull().NotEmpty();
            RuleFor(b => b.Id).NotNull().NotEmpty();
        }
    }
}
