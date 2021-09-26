using Library.ApiContracts;
using Library.Application;
using Library.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Library.GraphQL
{
    public class Mutation
    {
        private readonly FeatureFlags featureFlags;
        private readonly IUserApplication userApplication;

        public Mutation(IOptions<FeatureFlags> featureFlags, IUserApplication userApplication)
        {
            this.featureFlags = featureFlags.Value;
            this.userApplication = userApplication;
        }

        public async Task<User?> CreateUser(string name)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Query not implemented");
            }

            var user = await userApplication.CreateUser(name);
            return user;
        }

        public async Task<User> CheckoutBook(Guid userId, Guid bookId)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Query not implemented");
            }

            await userApplication.CheckoutBook(userId, bookId);
            var user = await userApplication.Get(userId);
            return user!;
        }

        public async Task<User> ReturnBook(Guid userId, Guid bookId)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Query not implemented");
            }

            await userApplication.ReturnBook(userId, bookId);
            var user = await userApplication.Get(userId);
            return user!;
        }
    }
}
