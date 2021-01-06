using Library.Domain.Commands;
using Library.Domain.Commands.Events.Events;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Entities.User
{
    public class User : AggregateRoot
    {
        /// <summary>
        /// Used for deserialization
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="isInGoodStanding"></param>
        /// <param name="books"></param>
        [BsonConstructor]
        internal User(Guid id, string name, bool isInGoodStanding, List<CheckedOutBook> books)
        {
            Id = id;
            Name = name;
            IsInGoodStanding = isInGoodStanding;
            this.books = books;
        }

        /// <summary>
        /// Used by the UserFactory; prefer creating instances with that
        /// </summary>
        /// <param name="name"></param>
        internal User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsInGoodStanding = true;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool IsInGoodStanding { get; private set; }

        [BsonElement(nameof(Books))]
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
