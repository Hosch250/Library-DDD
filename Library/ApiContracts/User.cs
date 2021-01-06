using System;
using System.Collections.Generic;

namespace Library.ApiContracts
{
    public record User(Guid Id, string Name, bool IsInGoodStanding, List<CheckedOutBook> Books);
    public record CheckedOutBook(Guid BookId, DateTime CheckedOutOn, DateTime ReturnBy);
}
