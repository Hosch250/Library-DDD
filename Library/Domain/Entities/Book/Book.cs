using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Library.Domain.Entities.Book
{
    public class Book : AggregateRoot
    {
        /// <summary>
        /// Used for deserialization
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isbn"></param>
        /// <param name="name"></param>
        /// <param name="publishedOn"></param>
        /// <param name="publisher"></param>
        /// <param name="authors"></param>
        [BsonConstructor]
        internal Book(Guid id, string isbn, string name, DateTime publishedOn, PublishingHouse publisher, List<Author> authors)
        {
            Id = id;
            Isbn = isbn;
            Name = name;
            PublishedOn = publishedOn;
            Publisher = publisher;
            this.authors = authors;
        }

        public Book(string isbn, string name, PublishingHouse publisher, List<Author> Authors)
        {
            Id = Guid.NewGuid();
            Isbn = isbn;
            Name = name;
            Publisher = publisher;
            this.authors = Authors;
        }

        public Guid Id { get; private set; }
        public string Isbn { get; private set; }
        public string Name { get; private set; }
        public DateTime PublishedOn { get; private set; }
        public PublishingHouse Publisher { get; private set; }

        [BsonElement(nameof(Authors))]
        private readonly List<Author> authors = new();
        public IReadOnlyCollection<Author> Authors => authors.AsReadOnly();
    }
}
