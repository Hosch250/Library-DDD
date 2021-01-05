using Library.Infrastructure.Storage.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Library.Infrastructure.Storage
{
    public class LibraryContext
    {
        public LibraryContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            var mongoConnectionUrl = new MongoUrl(connectionString);
            var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);

#if Debug
            mongoClientSettings.ClusterConfigurator = cb => {
                cb.Subscribe<CommandStartedEvent>(e => {
                    System.Diagnostics.Debug.WriteLine($"{e.CommandName} - {e.Command.ToJson()}");
                });
            };
#endif

            var client = new MongoClient(mongoClientSettings);
            var database = client.GetDatabase("Library");

            Book = new MongoRepository<BookEntity>(database.GetCollection<BookEntity>("Book"));
            User = new MongoRepository<UserEntity>(database.GetCollection<UserEntity>("User"));
        }

        public IRepository<BookEntity> Book { get; } = null!;
        public IRepository<UserEntity> User { get; } = null!;
    }
}