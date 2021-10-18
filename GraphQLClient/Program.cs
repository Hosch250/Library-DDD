﻿using GraphQLClient.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

            var result = await client.AllBooks.ExecuteAsync();
            var data = result.Data;

            //var result1 = await client.CreateUser.ExecuteAsync("abcd");
            //var data1 = result1.Data;
        }
    }
}
