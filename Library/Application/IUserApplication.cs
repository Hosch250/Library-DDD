using System;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IUserApplication
    {
        Task<ApiContracts.User> CreateUser(string name);
        Task CheckoutBook(Guid userId, Guid bookId);
        Task ReturnBook(Guid userId, Guid bookId);
    }
}
