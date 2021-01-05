using Library.Infrastructure.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Domain.Entities.Book
{
    public class Book : AggregateRoot
    {
        internal Book() { }  // used for serialization

        public Book(string isbn, string name, PublishingHouse publisher, List<Author> authors)
        {
            Id = Guid.NewGuid();
            Isbn = isbn;
            Name = name;
            Publisher = publisher;
            this.authors = authors;
        }

        public Guid Id { get; private set; }
        public string Isbn { get; private set; }
        public string Name { get; private set; }
        public DateTime PublishedOn { get; private set; }
        public PublishingHouse Publisher { get; private set; }

        private readonly List<Author> authors = new();
        public IReadOnlyCollection<Author> Authors => authors.AsReadOnly();
    }
}
