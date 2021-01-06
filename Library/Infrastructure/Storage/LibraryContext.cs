using Library.Domain.Entities.Book;
using Library.Domain.Entities.User;
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

            Book = new Collection<Book>(database.GetCollection<Book>("Book"));
            User = new Collection<User>(database.GetCollection<User>("User"));
        }

        public ICollection<Book> Book { get; } = null!;
        public ICollection<User> User { get; } = null!;
    }
}