using Library.Domain.Entities;
using Library.Domain.Entities.Book;
using Library.Domain.Entities.User;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Storage
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryContext libraryContext;

        public LibraryRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public async Task<IReadOnlyList<Book>> GetAllBooksAsync()
        {
            return await libraryContext.Book.AsQueryable().ToListAsync();
        }

        public async Task<Book?> GetBookAsync(Guid bookId)
        {
            return await libraryContext.Book.AsQueryable().FirstOrDefaultAsync(f => f.Id == bookId);
        }

        public async Task<IReadOnlyList<Book>> GetBooksAsync(IReadOnlyList<Guid> ids)
        {
            return await libraryContext.Book.AsQueryable().Where(f => ids.Contains(f.Id)).ToListAsync();
        }

        public async Task<bool> IsBookCheckedOut(Guid bookId)
        {
            var filter = Builders<User>.Filter.AnyEq($"{nameof(User.Books)}.{nameof(CheckedOutBook.BookId)}", bookId);

            return await libraryContext.User.CountDocumentsAsync(filter) > 0;
        }

        public async Task<User?> GetUserAsync(Guid userId)
        {
            return await libraryContext.User.AsQueryable().FirstOrDefaultAsync(f => f.Id == userId);
        }

        public async Task<IReadOnlyList<User>> GetUsersAsync(IReadOnlyList<Guid> ids)
        {
            return await libraryContext.User.AsQueryable().Where(f => ids.Contains(f.Id)).ToListAsync();
        }

        public async Task Update<T>(T model) where T : AggregateRoot
        {
            switch (model)
            {
                case Book book:
                    await libraryContext.Book.ReplaceOneAsync(b => b.Id == book.Id, book);
                    break;
                case User user:
                    await libraryContext.User.ReplaceOneAsync(u => u.Id == user.Id, user);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public async Task Insert<T>(T model) where T : AggregateRoot
        {
            switch (model)
            {
                case Book book:
                    await libraryContext.Book.InsertOneAsync(book);
                    break;
                case User user:
                    await libraryContext.User.InsertOneAsync(user);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
