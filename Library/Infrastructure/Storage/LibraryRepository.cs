using Library.Domain.Entities;
using Library.Domain.Entities.Book;
using Library.Domain.Entities.User;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Storage
{
    public class LibraryRepository
    {
        private readonly LibraryContext libraryContext;

        public LibraryRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await libraryContext.Book.AsQueryable().ToListAsync();
        }

        public async Task<Book?> GetBookAsync(Guid bookId)
        {
            return await libraryContext.Book.AsQueryable().FirstOrDefaultAsync(f => f.Id == bookId);
        }

        public async Task<bool> IsBookCheckedOut(Guid bookId)
        {
            var collection = libraryContext.User.GetCollection();
            var filter = Builders<User>.Filter.AnyEq($"{nameof(User.Books)}.{nameof(CheckedOutBook.BookId)}", bookId);

            return await collection.CountDocumentsAsync(filter) > 0;
        }

        public async Task<User?> GetUserAsync(Guid userId)
        {
            return await libraryContext.User.AsQueryable().FirstOrDefaultAsync(f => f.Id == userId);
        }

        public async Task Update<T>(T model) where T : AggregateRoot
        {
            switch (model)
            {
                case Book book:
                    await libraryContext.Book.Update(b => b.Id == book.Id, book);
                    break;
                case User user:
                    await libraryContext.User.Update(u => u.Id == user.Id, user);
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
                    await libraryContext.Book.Add(book);
                    break;
                case User user:
                    await libraryContext.User.Add(user);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
