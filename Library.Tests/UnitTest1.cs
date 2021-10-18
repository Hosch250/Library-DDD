using HotChocolate;
using HotChocolate.Execution;
using Library.GraphQL;
using Library.Infrastructure.Configuration;
using Library.Infrastructure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var options = Options.Create(new FeatureFlags
            {
                EnableBook = false
            });

            var resolver = new Query(options);

            Assert.ThrowsAsync<QueryException>(async () => await resolver.GetAllBooks(null).ToListAsync(CancellationToken.None), "Query not implemented");
        }

        public record Result(DataResult data);
        public record DataResult(AllBooksResult allBooks);
        public record AllBooksResult(List<ApiContracts.Book> nodes);

        [Test]
        public async Task Test2()
        {
            var booksQuery = @"query AllBooks {
  allBooks(order: [{ name: ASC }], last: 10) {
    nodes {
      id isbn name authors { name }
    }
  }
}";

            var services = new ServiceCollection();
            var builder = new ConfigurationBuilder()
     .SetBasePath(Environment.CurrentDirectory) //<--You would need to set the path
     .AddJsonFile("appsettings.Development.json"); //or what ever file you have the settings

            var configuration = builder.Build();

            services.AddScoped<IConfiguration>(_ => configuration);

            services.AddOptions<FeatureFlags>().Configure<IConfiguration>((settings, config) => config.GetSection("FeatureFlags").Bind(settings));
            services.AddTransient<LibraryContext>();
            services.AddSingleton(sp =>
            {
                return sp.GetRequiredService<LibraryContext>().BookDto;
            });

            IRequestExecutor executor =
                await services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddMongoDbFiltering()
                .AddMongoDbSorting()
                .AddMongoDbProjections()
                .AddMongoDbPagingProviders()
                .BuildRequestExecutorAsync();

            IExecutionResult result =
                await executor.ExecuteAsync(booksQuery);

            var json = result.ToJson();
            var data = JsonSerializer.Deserialize<Result>(json);
            Assert.AreEqual(3, data.data.allBooks.nodes.Count);
        }
    }
}