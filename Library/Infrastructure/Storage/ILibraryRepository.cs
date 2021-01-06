using Library.Domain.Entities;
using Library.Domain.Entities.Book;
using Library.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Infrastructure.Storage
{
    public interface ILibraryRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookAsync(Guid bookId);
        Task<bool> IsBookCheckedOut(Guid bookId);

        Task<User?> GetUserAsync(Guid userId);

        Task Insert<T>(T model) where T : AggregateRoot;
        Task Update<T>(T model) where T : AggregateRoot;
    }
}