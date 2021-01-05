using FluentValidation;
using Library.Domain.Commands;
using Library.Infrastructure.Storage;

namespace Library.Domain.Validators
{
    public class CheckingOutBookValidator : AbstractValidator<CheckoutBookCommand>
    {
        public CheckingOutBookValidator(LibraryRepository repository)
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (userId, _) =>
                {
                    var user = await repository.GetUserAsync(userId);
                    return user?.IsInGoodStanding == true;
                }).WithMessage("User is not in good standing");

            RuleFor(x => x.BookId)
                .MustAsync(async (bookId, _) => await repository.GetBookAsync(bookId) is not null)
                .WithMessage("Book does not exist")
                .DependentRules(() =>
                {
                    RuleFor(x => x.BookId)
                        .MustAsync(async (bookId, _) => !await repository.IsBookCheckedOut(bookId))
                        .WithMessage("Book is already checked out");
                });
        }
    }
}
