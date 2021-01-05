using Library.Domain.Commands;
using Library.Domain.Commands.Events.Events;
using Library.Infrastructure.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Entities.User
{
    public class User : AggregateRoot
    {
        internal User() { }  // used for serialization

        internal User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsInGoodStanding = true;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsInGoodStanding { get; private set; }

        private readonly List<CheckedOutBook> books = new();
        public IReadOnlyCollection<CheckedOutBook> Books => books.AsReadOnly();

        public async Task CheckoutBook(CheckoutBookCommand command)
        {
            // validation happens in any event handler listening for this event
            // e.g. Does the library have this book, is it available, etc.
            await DomainEvents.Raise(new CheckingOutBook(command));

            var checkoutTime = DateTime.UtcNow;
            books.Add(new CheckedOutBook(command.BookId, checkoutTime, checkoutTime.Date.AddDays(21)));
            //DomainEvents.Raise(new CheckedOutBook(command));
        }

        public async Task ReturnBook(ReturnBookCommand command)
        {
            // validation happens in any event handler listening for this event
            // e.g. Does the user have this book checked out, etc.
            await DomainEvents.Raise(new ReturningBook(command));

            books.RemoveAll(r => r.BookId == command.BookId);
            //DomainEvents.Raise(new ReturnedBook(command));
        }
    }
}
