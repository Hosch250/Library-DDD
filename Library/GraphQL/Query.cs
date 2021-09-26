using Library.ApiContracts;
using Library.Application;
using Library.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.GraphQL
{
    public class Query
    {
        private readonly FeatureFlags featureFlags;
        private readonly IBookApplication bookApplication;
        private readonly IUserApplication userApplication;

        public Query(IOptions<FeatureFlags> featureFlags, IBookApplication bookApplication, IUserApplication userApplication)
        {
            this.featureFlags = featureFlags.Value;
            this.bookApplication = bookApplication;
            this.userApplication = userApplication;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            if (!featureFlags.EnableBook)
            {
                throw new NotImplementedException("Query not implemented");
            }

            var books = await bookApplication.GetAll();
            return books;
        }

        public async Task<Book?> GetBook(Guid bookId)
        {
            if (!featureFlags.EnableBook)
            {
                throw new NotImplementedException("Query not implemented");
            }

            var book = await bookApplication.Get(bookId);
            return book;
        }

        public async Task<User?> GetUser(Guid userId)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Query not implemented");
            }

            var user = await userApplication.Get(userId);
            return user;
        }
    }
}
