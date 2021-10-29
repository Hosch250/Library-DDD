using System;
using System.Collections.Generic;

namespace Library.ApiContracts
{
    public record User(Guid Id, string Name, bool IsInGoodStanding, List<CheckedOutBook> Books);
    public record CheckedOutBook(Guid BookId, DateTime CheckedOutOn, DateTime ReturnBy);
    public record CheckedOutBookDetails(Guid Id, string Isbn, string Name, DateTime PublishedOn, PublishingHouse Publisher, List<Author> Authors, DateTime CheckedOutOn, DateTime ReturnBy) : Book(Id, Isbn, Name, PublishedOn, Publisher, Authors);
}
