using HotChocolate;
using HotChocolate.Types.Relay;
using Library.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.ApiContracts
{
    [Node]
    public record User(Guid Id, string Name, bool IsInGoodStanding, List<CheckedOutBook> Books)
    {
        public static async Task<User?> GetAsync(Guid id, [Service] IUserApplication userApp)
        {
            return await userApp.Get(id);
        }
    }
    public record CheckedOutBook(Guid BookId, DateTime CheckedOutOn, DateTime ReturnBy);

    public record CreateUserInput(string Name);
    public record CreateUserPayload(User? User);

    public record CheckoutBookInput([property: ID] Guid BookId, [property: ID] Guid UserId);
    public record CheckoutBookPayload(User? User);

    public record ReturnBookInput([property: ID] Guid BookId, [property: ID] Guid UserId);
    public record ReturnBookPayload(User? User);
}
