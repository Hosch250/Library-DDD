using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IUserApplication
    {
        Task<ApiContracts.User?> GetUser(Guid id);
        Task<IReadOnlyList<ApiContracts.User>> GetUsers(IReadOnlyList<Guid> ids);
        Task<ApiContracts.User> CreateUser(string name);
        Task CheckoutBook(Guid userId, Guid bookId);
        Task ReturnBook(Guid userId, Guid bookId);
    }
}
