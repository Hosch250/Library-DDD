using Library.Domain.Entities;
using Library.Domain.Entities.Book;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Library.Infrastructure.Storage.Entities
{
    public record BookEntity([property: BsonId] Guid Id, string Isbn, string Name, DateTime PublishedOn, PublishingHouseEntity Publisher, List<AuthorEntity> Authors, string AuditInfo_CreatedBy, DateTime AuditInfo_CreatedOn) : BaseEntity(AuditInfo_CreatedBy, AuditInfo_CreatedOn)
    {
        public Book MapToDomainModel()
        {
            var model = new Book();

            var modelType = typeof(Book);
            modelType.GetProperty(nameof(Book.Id))!.SetValue(model, Id);
            modelType.GetProperty(nameof(Book.Isbn))!.SetValue(model, Isbn);
            modelType.GetProperty(nameof(Book.Name))!.SetValue(model, Name);
            modelType.GetProperty(nameof(Book.PublishedOn))!.SetValue(model, PublishedOn);
            modelType.GetProperty(nameof(Book.Publisher))!.SetValue(model, new PublishingHouse(Publisher.Name));
            modelType.GetField("authors", BindingFlags.NonPublic | BindingFlags.Instance)!.SetValue(model, Authors.Select(s => new Author(s.Name, s.BirthDate, s.DeathDate)).ToList());

            var aggregateRootType = typeof(AggregateRoot);
            aggregateRootType.GetProperty(nameof(AggregateRoot.AuditInfo_CreatedBy))!.SetValue(model, AuditInfo_CreatedBy);
            aggregateRootType.GetProperty(nameof(AggregateRoot.AuditInfo_CreatedOn))!.SetValue(model, AuditInfo_CreatedOn);

            return model;
        }

        public static BookEntity FromModel(Book book)
        {
            return new BookEntity(book.Id, book.Isbn, book.Name, book.PublishedOn, new PublishingHouseEntity(book.Publisher.Name), book.Authors.Select(s => new AuthorEntity(s.Name, s.BirthDate, s.DeathDate)).ToList(), book.AuditInfo_CreatedBy, book.AuditInfo_CreatedOn);
        }
    }

    public record PublishingHouseEntity(string Name);
    public record AuthorEntity(string Name, DateTime? BirthDate, DateTime? DeathDate);
}
