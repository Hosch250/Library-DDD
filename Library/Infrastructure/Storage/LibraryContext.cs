using Library.Domain.Entities.Book;
using Library.Domain.Entities.User;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;

namespace Library.Infrastructure.Storage
{
    public class LibraryContext
    {
        public LibraryContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            var mongoConnectionUrl = new MongoUrl(connectionString);
            var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);

#if DEBUG
            mongoClientSettings.ClusterConfigurator = cb =>
            {
                cb.Subscribe<CommandStartedEvent>(e =>
                {
                    System.Diagnostics.Debug.WriteLine($"{e.CommandName} - {e.Command.ToJson()}");
                });
            };
#endif

            var client = new MongoClient(mongoClientSettings);
            var database = client.GetDatabase("Library");

            Book = database.GetCollection<Book>("Book");
            User = database.GetCollection<User>("User");
        }

        public IMongoCollection<Book> Book { get; } = null!;
        public IMongoCollection<User> User { get; } = null!;
    }
}