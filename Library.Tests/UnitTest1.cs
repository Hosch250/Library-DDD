using Library.ApiContracts;
using Library.Application;
using Library.GraphQL;
using Library.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var options = Options.Create(new FeatureFlags
            {
                EnableBook = false
            });

            var resolver = new QueryBookResolvers(options, null);

            Assert.ThrowsAsync<NotImplementedException>(() => resolver.GetAllBooks());
        }

        [Test]
        public async Task Test2()
        {
            var options = Options.Create(new FeatureFlags
            {
                EnableBook = true
            });

            var bookApp = new Mock<IBookApplication>();
            bookApp.Setup(s => s.GetAll()).ReturnsAsync(new List<Book>
            {
                new Book(Guid.NewGuid(), "asdf", "test book", DateTime.UtcNow, new PublishingHouse("name"), new List<Author>())
            });

            var resolver = new QueryBookResolvers(options, bookApp.Object);
            var books = await resolver.GetAllBooks();
            Assert.AreEqual(1, books.Count);
        }
    }
}