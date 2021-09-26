using System;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IUserApplication
    {
        Task<ApiContracts.User?> Get(Guid userId);
        Task<ApiContracts.User> CreateUser(string name);
        Task CheckoutBook(Guid userId, Guid bookId);
        Task ReturnBook(Guid userId, Guid bookId);
    }
}
