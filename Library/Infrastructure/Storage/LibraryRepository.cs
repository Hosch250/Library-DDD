using Library.Domain.Entities;
using Library.Domain.Entities.Book;
using Library.Domain.Entities.User;
using Library.Infrastructure.Storage.Entities;
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
            var books = await libraryContext.Book.AsQueryable().ToListAsync();
            return System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(books, s => s.MapToDomainModel()));
        }

        public async Task<Book?> GetBookAsync(Guid bookId)
        {
            var book = await libraryContext.Book.AsQueryable().FirstOrDefaultAsync(f => f.Id == bookId);
            return book?.MapToDomainModel();
        }

        public async Task<bool> IsBookCheckedOut(Guid bookId)
        {
            return await libraryContext.User.AsQueryable().AnyAsync(f => f.Books.Any(b => b.BookId == bookId));
        }

        public async Task<User?> GetUserAsync(Guid userId)
        {
            var user = await libraryContext.User.AsQueryable().FirstOrDefaultAsync(f => f.Id == userId);
            return user?.MapToDomainModel();
        }

        public async Task Update<T>(T model) where T : AggregateRoot
        {
            switch (model)
            {
                case Book book:
                    await libraryContext.Book.Update(b => b.Id == book.Id, BookEntity.FromModel(book));
                    break;
                case User user:
                    await libraryContext.User.Update(u => u.Id == user.Id, UserEntity.FromModel(user));
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
                    await libraryContext.Book.Add(BookEntity.FromModel(book));
                    break;
                case User user:
                    await libraryContext.User.Add(UserEntity.FromModel(user));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
