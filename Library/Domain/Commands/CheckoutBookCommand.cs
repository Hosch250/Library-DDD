using System;

namespace Library.Domain.Commands
{
    public class CheckoutBookCommand
    {
        public Guid BookId { get; }
        public Guid UserId { get; }

        public CheckoutBookCommand(Guid userId, Guid bookId)
        {
            if (bookId == Guid.Empty) { throw new ArgumentException($"Argument {nameof(bookId)} cannot be an empty guid", nameof(bookId)); }
            if (userId == Guid.Empty) { throw new ArgumentException($"Argument {nameof(userId)} cannot be an empty guid", nameof(userId)); }

            BookId = bookId;
            UserId = userId;
        }
    }
}
