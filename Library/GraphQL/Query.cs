using HotChocolate;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using Library.ApiContracts;
using Library.Application;
using Library.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQL
{
    public class Query
    {
    }

    [ExtendObjectType(typeof(Query))]
    public class QueryBookResolvers
    {
        private readonly FeatureFlags featureFlags;
        private readonly IBookApplication bookApplication;

        public QueryBookResolvers(IOptions<FeatureFlags> featureFlags, IBookApplication bookApplication)
        {
            this.featureFlags = featureFlags.Value;
            this.bookApplication = bookApplication;
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
    }

    [ExtendObjectType(typeof(Query))]
    public class QueryUserResolvers
    {
        private readonly FeatureFlags featureFlags;
        private readonly IUserApplication userApplication;

        public QueryUserResolvers(IOptions<FeatureFlags> featureFlags, IUserApplication userApplication)
        {
            this.featureFlags = featureFlags.Value;
            this.userApplication = userApplication;
        }

        public async Task<User?> GetUser(Guid id, IResolverContext context)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Query not implemented");
            }

            return await context.BatchDataLoader<Guid, User>(
                async (keys, ct) =>
                {
                    var users = await userApplication.GetUsers(keys);
                    return users.ToDictionary(x => x.Id);
                })
            .LoadAsync(id);
        }
    }
}
