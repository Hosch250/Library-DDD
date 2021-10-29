using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Library.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public async Task Disabled()
        {
            var options = new Dictionary<string, string>
            {
                ["FeatureFlags:EnableBook"] = bool.FalseString,
                ["ConnectionStrings:Database"] = "mongodb://localhost"
            };

            var config = new ConfigurationBuilder().AddInMemoryCollection(options);

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config.Build());
            new Startup(config.Build()).ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var builder = await serviceProvider.ExecuteRequestAsync(@"query { allBooks { id } }");
            Assert.Single(builder.Errors);
            Assert.Equal("NotImplemented", builder.Errors[0].Code);
        }

        [Fact]
        public async Task ReturnsBooks()
        {
            var options = new Dictionary<string, string>
            {
                ["FeatureFlags:EnableBook"] = bool.TrueString,
                ["ConnectionStrings:Database"] = "mongodb://localhost"
            };

            var config = new ConfigurationBuilder().AddInMemoryCollection(options);

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config.Build());
            new Startup(config.Build()).ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var builder = await serviceProvider.ExecuteRequestAsync(@"query { allBooks { id name } }");
            var result = builder.ToJson();
            var expected = @"{
  ""data"": {
    ""allBooks"": [
      {
        ""id"": ""30558e66-f0df-4dcd-aa96-1b3d329f1b86"",
        ""name"": ""C# in Depth: 4th Edition""
      },
      {
        ""id"": ""01ae6518-07fe-49ad-9be3-b1236e86d5b2"",
        ""name"": ""GraphQL in Action""
      },
      {
        ""id"": ""0a08e8df-b71e-4300-9683-bd4a1b7bcaf1"",
        ""name"": ""Dependency Injection Principles, Practices, and Patterns""
      }
    ]
  }
}";

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task ReturnsUser()
        {
            var options = new Dictionary<string, string>
            {
                ["FeatureFlags:EnableUser"] = bool.TrueString,
                ["ConnectionStrings:Database"] = "mongodb://localhost"
            };

            var config = new ConfigurationBuilder().AddInMemoryCollection(options);

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config.Build());
            new Startup(config.Build()).ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var builder = await serviceProvider.ExecuteRequestAsync(@"query { user(id: ""e796b1ed-dce1-4302-9d74-c5a543f8cae6"") { id name books { id name } } }");
            var result = builder.ToJson();
            var expected = @"{
  ""data"": {
    ""user"": {
      ""id"": ""e796b1ed-dce1-4302-9d74-c5a543f8cae6"",
      ""name"": ""Abraham Hosch"",
      ""books"": [
        {
          ""id"": ""30558e66-f0df-4dcd-aa96-1b3d329f1b86"",
          ""name"": ""C# in Depth: 4th Edition""
        },
        {
          ""id"": ""0a08e8df-b71e-4300-9683-bd4a1b7bcaf1"",
          ""name"": ""Dependency Injection Principles, Practices, and Patterns""
        }
      ]
    }
  }
}";

            Assert.Equal(expected, result);
        }
    }
}