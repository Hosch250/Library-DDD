using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Execution;
using Library.ApiContracts;
using Library.Application;
using Library.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Library.GraphQL
{
    public class Mutation
    {
        private readonly FeatureFlags featureFlags;
        private readonly IUserApplication userApplication;
        private readonly Query query;

        public Mutation(IOptions<FeatureFlags> featureFlags, IUserApplication userApplication, Query query)
        {
            this.featureFlags = featureFlags.Value;
            this.userApplication = userApplication;
            this.query = query;
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IExecutable<User>> CreateUser([Service] IMongoCollection<User> collection, string name)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Query not implemented");
            }

            try
            {
                await userApplication.CreateUser(name);
            }
            catch (FluentValidation.ValidationException ex)
            {
                throw new QueryException(ex.Message);
            }

            return collection.Find(x => x.Name == name).AsExecutable();
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IExecutable<User>> CheckoutBook([Service] IMongoCollection<User> collection, Guid userId, Guid bookId)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Query not implemented");
            }

            try
            {
                await userApplication.CheckoutBook(userId, bookId);
            }
            catch(FluentValidation.ValidationException ex)
            {
                throw new QueryException(ex.Message);
            }

            return collection.Find(x => x.Id == userId).AsExecutable();
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<IExecutable<User>> ReturnBook([Service] IMongoCollection<User> collection, Guid userId, Guid bookId)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Query not implemented");
            }

            try
            {
                await userApplication.ReturnBook(userId, bookId);
            }
            catch (FluentValidation.ValidationException ex)
            {
                throw new QueryException(ex.Message);
            }

            return collection.Find(x => x.Id == userId).AsExecutable();
        }
    }
}
