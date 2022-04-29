using GraphQLClient.Client;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using StrawberryShake;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GraphQLClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44377") });

            serviceCollection
                .AddLibraryClient()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:44377/graphql"));

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var client = serviceProvider.GetRequiredService<ILibraryClient>();

            var result = await client.App.ExecuteAsync();
            var data = result.Data;

            data.AllBooks.Nodes[0].MockedField = "test";
            var mockedData = data.AllBooks.Nodes[0].MockedField;

            var createUserResult = await client.CreateUser.ExecuteAsync("abcd");
            var createdUser = createUserResult.Data;
        }
    }

    class Tests
    {
        [Test]
        public void MockAppQuery()
        {
            var mockResult = new Mock<IOperationResult<IAppResult>>();
            mockResult.Setup(s => s.Data).Returns(new AppResult(
                new App_AllBooks_AllBooksConnection(new List<App_AllBooks_Nodes_Book>
                {
                    new App_AllBooks_Nodes_Book(Guid.NewGuid(), "978-1617294532", "C# In Depth, Fourth Edition")
                })
            ));

            var mockAppQuery = new Mock<IAppQuery>();
            mockAppQuery.Setup(s => s.ExecuteAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockResult.Object);

            var mockClient = new Mock<ILibraryClient>();
            mockClient.Setup(s => s.App).Returns(mockAppQuery.Object);

            // todo: act

            // todo: assert
        }
    }
}

namespace GraphQLClient.Client
{
    public partial interface IApp_AllBooks_Nodes
    {
        public string MockedField { get; set; }
    }
    public partial class App_AllBooks_Nodes_Book
    {
        public string MockedField { get; set; }
    }
}