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
        public async Task<CreateUserPayload> CreateUser([Service] IMongoCollection<User> collection, CreateUserInput input)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Mutation not implemented");
            }

            try
            {
                var user = await userApplication.CreateUser(input.Name);
                return new CreateUserPayload(user);
            }
            catch (FluentValidation.ValidationException ex)
            {
                throw new QueryException(ex.Message);
            }
        }

        [UseProjection]
        public async Task<CheckoutBookPayload> CheckoutBook([Service] IUserApplication userApp, CheckoutBookInput input)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Mutation not implemented");
            }

            try
            {
                await userApplication.CheckoutBook(input.UserId, input.BookId);
            }
            catch(FluentValidation.ValidationException ex)
            {
                throw new QueryException(ex.Message);
            }

            var user = await userApp.Get(input.UserId);
            return new CheckoutBookPayload(user);
        }

        [UseFirstOrDefault]
        [UseProjection]
        public async Task<ReturnBookPayload> ReturnBook([Service] IUserApplication userApp, ReturnBookInput input)
        {
            if (!featureFlags.EnableUser)
            {
                throw new NotImplementedException("Mutation not implemented");
            }

            try
            {
                await userApplication.ReturnBook(input.UserId, input.BookId);
            }
            catch (FluentValidation.ValidationException ex)
            {
                throw new QueryException(ex.Message);
            }

            var user = await userApp.Get(input.UserId);
            return new ReturnBookPayload(user);
        }
    }
}
