using FluentValidation;
using Library.Domain.Commands;
using Library.Infrastructure.Storage;

namespace Library.Domain.Validators
{
    public class ReturningBookValidator : AbstractValidator<ReturnBookCommand>
    {
        public ReturningBookValidator(ILibraryRepository repository)
        {
            RuleFor(x => x.BookId)
                .MustAsync(async (bookId, _) => await repository.GetBookAsync(bookId) is not null)
                .WithMessage("Book does not exist");

            RuleFor(x => x)
                .MustAsync(async (command, _) =>
                {
                    var user = await repository.GetUserAsync(command.UserId);
                    return System.Linq.Enumerable.Any(user!.Books, a => a.BookId == command.BookId);

                }).WithMessage("User does not have book checked out");
        }
    }
}
