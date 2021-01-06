using System;
using System.Collections.Generic;

namespace Library.ApiContracts
{
    public record Book(Guid Id, string Isbn, string Name, DateTime PublishedOn, PublishingHouse Publisher, List<Author> Authors);
    public record PublishingHouse(string Name);
    public record Author(string Name, DateTime? BirthDate, DateTime? DeathDate);


}
