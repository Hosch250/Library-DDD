using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Execution;
using HotChocolate.Types;
using Library.ApiContracts;
using Library.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Library.GraphQL
{
    public class Query
    {
        private readonly FeatureFlags featureFlags;

        public Query(IOptions<FeatureFlags> featureFlags)
        {
            this.featureFlags = featureFlags.Value;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IExecutable<Book> GetAllBooks([Service] IMongoCollection<Book> collection)
        {
            if (!featureFlags.EnableBook)
            {
                throw new QueryException("Query not implemented");
            }
            
            return collection.AsExecutable();
        }

        [UseFirstOrDefault]
        [UseProjection]
        public IExecutable<Book> GetBook(
            [Service] IMongoCollection<Book> collection,
            Guid id)
        {
            if (!featureFlags.EnableBook)
            {
                throw new QueryException("Query not implemented");
            }

            return collection.Find(x => x.Id == id).AsExecutable();
        }

        //public async Task<List<Book>> GetAllBooks()
        //{
        //    if (!featureFlags.EnableBook)
        //    {
        //        throw new NotImplementedException("Query not implemented");
        //    }

        //    var books = await bookApplication.GetAll();
        //    return books;
        //}

        //public async Task<Book?> GetBook(Guid bookId)
        //{
        //    if (!featureFlags.EnableBook)
        //    {
        //        throw new NotImplementedException("Query not implemented");
        //    }

        //    var book = await bookApplication.Get(bookId);
        //    return book;
        //}

        [UseFirstOrDefault]
        [UseProjection]
        public IExecutable<User> GetUser(
            [Service] IMongoCollection<User> collection, Guid id)
        {
            if (!featureFlags.EnableUser)
            {
                throw new QueryException("Query not implemented");
            }

            return collection.Find(x => x.Id == id).AsExecutable();
        }
    }
}
