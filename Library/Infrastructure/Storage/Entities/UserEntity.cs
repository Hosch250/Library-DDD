using Library.Domain.Entities;
using Library.Domain.Entities.User;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Library.Infrastructure.Storage.Entities
{
    public record UserEntity([property: BsonId] Guid Id, string Name, bool IsInGoodStanding, List<CheckedOutBookEntity> Books, string AuditInfo_CreatedBy, DateTime AuditInfo_CreatedOn) : BaseEntity(AuditInfo_CreatedBy, AuditInfo_CreatedOn)
    {
        public User MapToDomainModel()
        {
            var model = new User();

            var modelType = typeof(User);
            modelType.GetProperty(nameof(User.Id))!.SetValue(model, Id);
            modelType.GetProperty(nameof(User.Name))!.SetValue(model, Name);
            modelType.GetProperty(nameof(User.IsInGoodStanding))!.SetValue(model, IsInGoodStanding);
            modelType.GetField("books", BindingFlags.NonPublic | BindingFlags.Instance)!.SetValue(model, Books.Select(s => new CheckedOutBook(s.BookId, s.CheckedOutOn, s.ReturnBy)).ToList());

            var aggregateRootType = typeof(AggregateRoot);
            aggregateRootType.GetProperty(nameof(AggregateRoot.AuditInfo_CreatedBy))!.SetValue(model, AuditInfo_CreatedBy);
            aggregateRootType.GetProperty(nameof(AggregateRoot.AuditInfo_CreatedOn))!.SetValue(model, AuditInfo_CreatedOn);

            return model;
        }

        public static UserEntity FromModel(User user)
        {
            return new UserEntity(user.Id, user.Name, user.IsInGoodStanding, user.Books.Select(s => new CheckedOutBookEntity(s.BookId, s.CheckedOutOn, s.ReturnBy)).ToList(), user.AuditInfo_CreatedBy, user.AuditInfo_CreatedOn);
        }
    }

    public record CheckedOutBookEntity(Guid BookId, DateTime CheckedOutOn, DateTime ReturnBy);
}
