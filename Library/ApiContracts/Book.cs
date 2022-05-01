using HotChocolate;
using HotChocolate.Types.Relay;
using Library.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.ApiContracts
{
    [Node]
    public record Book(Guid Id, string Isbn, string Name, DateTime PublishedOn, PublishingHouse Publisher, List<Author> Authors)
    {
        public static async Task<Book?> GetAsync(Guid id, [Service] IBookApplication bookApp)
        {
            return await bookApp.Get(id);
        }
    }
    public record PublishingHouse(string Name);
    public record Author(string Name, DateTime? BirthDate, DateTime? DeathDate);
}
